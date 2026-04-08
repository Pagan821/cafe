using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Система_учета_заказов_в_кафешке.Database;
using MenuItemModel = Система_учета_заказов_в_кафешке.Models.MenuItem;
using OrderItemModel = Система_учета_заказов_в_кафешке.Models.OrderItem;

namespace Система_учета_заказов_в_кафешке
{
    public partial class MainForm : Form
    {
        private DatabaseService _db;
        private string _currentUser;
        private string _currentRole;
        private int nextOrderNumber = 1;
        private List<OrderItemModel> currentOrderItems = new List<OrderItemModel>();
        private List<MenuItemModel> menuItems = new List<MenuItemModel>();
        private int? selectedMenuItemId = null;
        private int? selectedUserId = null;

        public MainForm(string username, string role)
        {
            _currentUser = username;
            _currentRole = role;
            _db = DatabaseService.Instance;
            InitializeComponent();
            InitializeForm();
            LoadDataFromDatabase();
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (timerClock != null)
            {
                timerClock.Stop();
                timerClock.Dispose();
            }

            if (timerRefreshDisplay != null)
            {
                timerRefreshDisplay.Stop();
                timerRefreshDisplay.Dispose();
            }
            if (_db != null && _db is IDisposable disposable)
            {
                disposable.Dispose();
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void InitializeForm()
        {
            comboBoxStatusFilter.SelectedIndex = 0;
            comboBoxCategory.SelectedIndex = 0;
            comboBoxRole.SelectedIndex = 0;
            chkShowOnlyAvailable.Checked = true;
            chkShowOnlyAvailable.CheckedChanged += ChkShowOnlyAvailable_CheckedChanged;

            dateTimePickerStart.Value = DateTime.Today;
            dateTimePickerEnd.Value = DateTime.Today.AddDays(1);

            toolStripStatusUser.Text = $"Пользователь: {_currentUser} ({_currentRole})";

            LoadDataFromDatabase();
            // Настройка прав доступа
            if (_currentRole != "Администратор")
            {
                tabPageAdmin.Enabled = false;
            }
            if (_currentRole == "Повар")
            {
                tabPageOrders.Enabled = false;
                tabPageHistory.Enabled = false;
            }

            dataGridViewPendingOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPendingOrders.MultiSelect = false;
            dataGridViewInProgress.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewInProgress.MultiSelect = false;
            dataGridViewActiveOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewActiveOrders.MultiSelect = false;
            dataGridViewMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMenu.MultiSelect = false;
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.MultiSelect = false;

            timerClock.Tick += TimerClock_Tick;
            timerRefreshDisplay.Tick += TimerRefreshDisplay_Tick;

            timerClock.Start();
            timerRefreshDisplay.Start();

            UpdateClock();

            btnCreateOrder.Click += BtnCreateOrder_Click;
            btnAddToOrder.Click += BtnAddToOrder_Click;
            btnCancelOrder.Click += BtnCancelOrder_Click;
            btnEditOrder.Click += BtnEditOrder_Click;
            btnRefreshOrders.Click += BtnRefreshOrders_Click;
            btnStartCooking.Click += BtnStartCooking_Click;
            btnMarkReady.Click += BtnMarkReady_Click;
            btnSearch.Click += BtnSearch_Click;
            btnExport.Click += BtnExport_Click;
            btnSaveMenuItem.Click += BtnSaveMenuItem_Click;
            btnUpdateMenuItem.Click += BtnUpdateMenuItem_Click;
            btnDeleteMenuItem.Click += BtnDeleteMenuItem_Click;
            btnAddMenuItem.Click += BtnAddMenuItem_Click;
            btnSalesReport.Click += BtnSalesReport_Click;
            btnPopularItemsReport.Click += BtnPopularItemsReport_Click;
            btnCookingTimeReport.Click += BtnCookingTimeReport_Click;
            btnShiftReport.Click += BtnShiftReport_Click;
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            refreshAllToolStripMenuItem.Click += RefreshAllToolStripMenuItem_Click;
            changeUserToolStripMenuItem.Click += ChangeUserToolStripMenuItem_Click;
            btnCancelExistingOrder.Click += BtnCancelExistingOrder_Click;

            // User management events
            dataGridViewUsers.CellClick += DataGridViewUsers_CellClick;
            dataGridViewUsers.CellDoubleClick += DataGridViewUsers_CellDoubleClick;
            btnSaveUser.Click += BtnSaveUser_Click;
            btnUpdateUser.Click += BtnUpdateUser_Click;
            btnDeleteUser.Click += BtnDeleteUser_Click;
            btnAddUser.Click += BtnAddUser_Click;

            if (btnCompleteOrder != null)
            {
                btnCompleteOrder.Click += BtnCompleteOrder_Click;
            }

            dataGridViewMenu.CellClick += DataGridViewMenu_CellClick;
            dataGridViewMenu.CellDoubleClick += DataGridViewMenu_CellDoubleClick;
            tabControlMain.SelectedIndexChanged += TabControlMain_SelectedIndexChanged;

            RefreshMenuGrid();
        }

        // Обработчик выхода из программы
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти из программы?",
                "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void LoadDataFromDatabase()
        {
            LoadMenuFromDatabase();
            LoadUsersFromDatabase();
            RefreshOrdersList();
            RefreshKitchenView();
        }

        private void LoadMenuFromDatabase()
        {
            menuItems = _db.GetAllMenuItems();
            RefreshAvailableItemsList();
            RefreshMenuGrid();
        }

        private void RefreshAvailableItemsList()
        {
            listBoxAvailableItems.Items.Clear();
            var items = chkShowOnlyAvailable.Checked
                ? menuItems.Where(m => m.IsAvailable)
                : menuItems;

            foreach (var item in items)
            {
                listBoxAvailableItems.Items.Add($"{item.Name} - {item.Price} руб.");
            }
        }

        private void ChkShowOnlyAvailable_CheckedChanged(object sender, EventArgs e)
        {
            RefreshAvailableItemsList();
        }

        private void LoadUsersFromDatabase()
        {
            var users = _db.GetAllUsers();
            dataGridViewUsers.Rows.Clear();
            foreach (var user in users)
            {
                dataGridViewUsers.Rows.Add(user.Id, user.Username, user.Role);
            }
        }

        private void UpdateClock()
        {
            toolStripStatusTime.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }

        private void TimerClock_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        private void TimerRefreshDisplay_Tick(object sender, EventArgs e)
        {
            RefreshDisplay();
        }

        private void BtnAddToOrder_Click(object sender, EventArgs e)
        {
            if (listBoxAvailableItems.SelectedItem != null)
            {
                string selectedItem = listBoxAvailableItems.SelectedItem.ToString();
                int quantity = (int)numericQuantity.Value;

                string[] parts = selectedItem.Split(new[] { " - " }, StringSplitOptions.None);
                string itemName = parts[0];
                decimal price = decimal.Parse(parts[1].Replace(" руб.", ""));

                var existingItem = currentOrderItems.FirstOrDefault(i => i.Name == itemName);
                if (existingItem != null)
                {
                    existingItem.Quantity += quantity;
                    existingItem.Total = existingItem.Price * existingItem.Quantity;
                    int index = currentOrderItems.IndexOf(existingItem);
                    listBoxCurrentOrder.Items[index] = $"{existingItem.Name} - {existingItem.Price:F2} руб. x{existingItem.Quantity} = {existingItem.Total:F2} руб.";
                }
                else
                {
                    var newItem = new OrderItemModel
                    {
                        Name = itemName,
                        Price = price,
                        Quantity = quantity,
                        Total = price * quantity
                    };
                    currentOrderItems.Add(newItem);
                    listBoxCurrentOrder.Items.Add($"{newItem.Name} - {newItem.Price:F2} руб. x{newItem.Quantity} = {newItem.Total:F2} руб.");
                }

                UpdateOrderTotal();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите блюдо", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateOrderTotal()
        {
            decimal total = currentOrderItems.Sum(i => i.Total);
            labelOrderTotal.Text = $"Итого: {total:F2} руб.";
        }

        private void BtnCreateOrder_Click(object sender, EventArgs e)
        {
            if (currentOrderItems.Count == 0)
            {
                MessageBox.Show("Добавьте блюда в заказ", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = currentOrderItems.Sum(i => i.Total);

            try
            {
                _db.CreateOrder(currentOrderItems, total);

                currentOrderItems.Clear();
                listBoxCurrentOrder.Items.Clear();
                labelOrderTotal.Text = "Итого: 0 руб.";

                MessageBox.Show($"Заказ создан! Ожидайте на мониторе статусов.",
                    "Заказ создан", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RefreshOrdersList();
                RefreshKitchenView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании заказа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelOrder_Click(object sender, EventArgs e)
        {
            if (currentOrderItems.Count > 0)
            {
                if (MessageBox.Show("Очистить текущий заказ?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    currentOrderItems.Clear();
                    listBoxCurrentOrder.Items.Clear();
                    labelOrderTotal.Text = "Итого: 0 руб.";
                }
            }
        }

        private void BtnEditOrder_Click(object sender, EventArgs e)
        {
            if (listBoxCurrentOrder.SelectedIndex >= 0)
            {
                currentOrderItems.RemoveAt(listBoxCurrentOrder.SelectedIndex);
                listBoxCurrentOrder.Items.RemoveAt(listBoxCurrentOrder.SelectedIndex);
                UpdateOrderTotal();
            }
        }

        private void RefreshOrdersList()
        {
            var orders = _db.GetAllOrders();
            dataGridViewActiveOrders.Rows.Clear();
            // Исключаем завершенные и отмененные заказы из активных
            var activeOrders = orders.Where(o => o.Status != "Завершен" && o.Status != "Отменен");

            foreach (var order in activeOrders)
            {
                string items = string.Join(", ", order.Items.Select(i => $"{i.Name} x{i.Quantity}"));
                dataGridViewActiveOrders.Rows.Add(
                    order.OrderNumber,
                    items,
                    order.Status,
                    order.OrderTime.ToString("HH:mm"),
                    $"{order.Total:F2} руб."
                );
            }
        }

        private void RefreshKitchenView()
        {
            var orders = _db.GetAllOrders();

            dataGridViewPendingOrders.Rows.Clear();
            // Только заказы со статусом "Ожидает" (не отмененные)
            var pendingOrders = orders.Where(o => o.Status == "Ожидает");
            foreach (var order in pendingOrders)
            {
                string items = string.Join(", ", order.Items.Select(i => $"{i.Name} x{i.Quantity}"));
                dataGridViewPendingOrders.Rows.Add(
                    order.OrderNumber,
                    items,
                    order.OrderTime.ToString("HH:mm")
                );
            }

            dataGridViewInProgress.Rows.Clear();
            // Только заказы со статусом "В работе" (не отмененные)
            var inProgressOrders = orders.Where(o => o.Status == "В работе");
            foreach (var order in inProgressOrders)
            {
                string items = string.Join(", ", order.Items.Select(i => $"{i.Name} x{i.Quantity}"));
                dataGridViewInProgress.Rows.Add(
                    order.OrderNumber,
                    items,
                    order.StartTime.HasValue ? order.StartTime.Value.ToString("HH:mm") : "-"
                );
            }
        }

        private void RefreshMenuGrid()
        {
            dataGridViewMenu.Rows.Clear();
            var sortedMenu = menuItems.OrderBy(m => GetCategoryOrder(m.Category)).ThenBy(m => m.Name);

            foreach (var item in sortedMenu)
            {
                dataGridViewMenu.Rows.Add(
                    item.Id,
                    item.Name,
                    item.Category,
                    $"{item.Price:F2}",
                    item.IsAvailable ? "Да" : "Нет"
                );
            }
        }

        private int GetCategoryOrder(string category)
        {
            switch (category)
            {
                case "Напитки": return 1;
                case "Закуски": return 2;
                case "Салаты": return 3;
                case "Горячие блюда": return 4;
                case "Десерты": return 5;
                default: return 99;
            }
        }

        private void DataGridViewMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewMenu.Rows[e.RowIndex];
                selectedMenuItemId = (int)row.Cells[0].Value;
                txtItemName.Text = row.Cells[1].Value?.ToString();
                numericPrice.Value = decimal.Parse(row.Cells[3].Value?.ToString() ?? "0");

                string category = row.Cells[2].Value?.ToString();
                if (category != null)
                {
                    int index = comboBoxCategory.Items.IndexOf(category);
                    if (index >= 0) comboBoxCategory.SelectedIndex = index;
                }

                btnSaveMenuItem.Enabled = false;
                btnUpdateMenuItem.Enabled = true;
                btnDeleteMenuItem.Enabled = true;

                labelItemName.Text = "Название блюда (редактирование):";
                groupBoxMenuItemDetails.Text = "Редактирование позиции меню";
            }
        }

        private void DataGridViewMenu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewMenu.Rows[e.RowIndex];
                selectedMenuItemId = (int)row.Cells[0].Value;
                txtItemName.Text = row.Cells[1].Value?.ToString();
                numericPrice.Value = decimal.Parse(row.Cells[3].Value?.ToString() ?? "0");

                string category = row.Cells[2].Value?.ToString();
                if (category != null)
                {
                    int index = comboBoxCategory.Items.IndexOf(category);
                    if (index >= 0) comboBoxCategory.SelectedIndex = index;
                }

                btnSaveMenuItem.Enabled = false;
                btnUpdateMenuItem.Enabled = true;
                btnDeleteMenuItem.Enabled = true;

                labelItemName.Text = "Название блюда (редактирование):";
                groupBoxMenuItemDetails.Text = "Редактирование позиции меню";
            }
        }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabPageAdmin)
            {
                LoadMenuFromDatabase();
                LoadUsersFromDatabase();
            }
            else if (tabControlMain.SelectedTab == tabPageOrders ||
                     tabControlMain.SelectedTab == tabPageKitchen)
            {
                RefreshOrdersList();
                RefreshKitchenView();
            }
            else if (tabControlMain.SelectedTab == tabPageDisplay)
            {
                RefreshDisplay();
            }
        }

        private void BtnStartCooking_Click(object sender, EventArgs e)
        {
            if (dataGridViewPendingOrders.SelectedRows.Count == 0 && dataGridViewPendingOrders.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите заказ из списка 'Ожидают приготовления'",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridViewPendingOrders.SelectedRows.Count > 0
                ? dataGridViewPendingOrders.SelectedRows[0]
                : dataGridViewPendingOrders.CurrentRow;

            if (selectedRow == null || selectedRow.Cells[0].Value == null)
            {
                MessageBox.Show("Пожалуйста, выберите заказ из списка 'Ожидают приготовления'",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderNumber = (int)selectedRow.Cells[0].Value;
            var order = _db.GetAllOrders().FirstOrDefault(o => o.OrderNumber == orderNumber);

            if (order != null && order.Status == "Ожидает")
            {
                if (_db.UpdateOrderStatus(order.Id, "В работе"))
                {
                    RefreshKitchenView();
                    RefreshOrdersList();
                    RefreshDisplay();
                    MessageBox.Show($"Заказ №{orderNumber} начали готовить!",
                        "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Выбранный заказ не найден или уже готовится",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnMarkReady_Click(object sender, EventArgs e)
        {
            if (dataGridViewInProgress.SelectedRows.Count == 0 && dataGridViewInProgress.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите заказ из списка 'В процессе приготовления'",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridViewInProgress.SelectedRows.Count > 0
                ? dataGridViewInProgress.SelectedRows[0]
                : dataGridViewInProgress.CurrentRow;

            if (selectedRow == null || selectedRow.Cells[0].Value == null)
            {
                MessageBox.Show("Пожалуйста, выберите заказ из списка 'В процессе приготовления'",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderNumber = (int)selectedRow.Cells[0].Value;
            var order = _db.GetAllOrders().FirstOrDefault(o => o.OrderNumber == orderNumber);

            if (order != null && order.Status == "В работе")
            {
                if (_db.UpdateOrderStatus(order.Id, "Готов"))
                {
                    RefreshKitchenView();
                    RefreshOrdersList();
                    RefreshDisplay();

                    MessageBox.Show($"Заказ №{orderNumber} готов! Клиент может забрать.",
                        "Заказ готов", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Выбранный заказ не найден или уже готов",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnCompleteOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewActiveOrders.SelectedRows.Count == 0 && dataGridViewActiveOrders.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите заказ из списка активных заказов",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridViewActiveOrders.SelectedRows.Count > 0
                ? dataGridViewActiveOrders.SelectedRows[0]
                : dataGridViewActiveOrders.CurrentRow;

            if (selectedRow == null || selectedRow.Cells[0].Value == null)
            {
                MessageBox.Show("Пожалуйста, выберите заказ из списка активных заказов",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderNumber = (int)selectedRow.Cells[0].Value;
            var order = _db.GetAllOrders().FirstOrDefault(o => o.OrderNumber == orderNumber);

            if (order != null)
            {
                DialogResult result = MessageBox.Show($"Завершить заказ №{orderNumber}?\n\nЗаказ будет перемещен в историю.",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (_db.UpdateOrderStatus(order.Id, "Завершен"))
                    {
                        RefreshOrdersList();
                        RefreshKitchenView();
                        RefreshDisplay();

                        MessageBox.Show($"Заказ №{orderNumber} завершен!",
                            "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Заказ не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelExistingOrder_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли заказ
            if (dataGridViewActiveOrders.SelectedRows.Count == 0 && dataGridViewActiveOrders.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите заказ из списка активных заказов",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridViewActiveOrders.SelectedRows.Count > 0
                ? dataGridViewActiveOrders.SelectedRows[0]
                : dataGridViewActiveOrders.CurrentRow;

            if (selectedRow == null || selectedRow.Cells[0].Value == null)
            {
                MessageBox.Show("Пожалуйста, выберите заказ из списка активных заказов",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderNumber = (int)selectedRow.Cells[0].Value;
            var order = _db.GetAllOrders().FirstOrDefault(o => o.OrderNumber == orderNumber);

            if (order != null)
            {
                // Проверяем, можно ли отменить заказ
                if (order.Status == "Завершен")
                {
                    MessageBox.Show($"Заказ №{orderNumber} уже завершен и не может быть отменен.",
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (order.Status == "Отменен")
                {
                    MessageBox.Show($"Заказ №{orderNumber} уже отменен.",
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string statusText = "";
                switch (order.Status)
                {
                    case "Ожидает":
                        statusText = "ожидает приготовления";
                        break;
                    case "В работе":
                        statusText = "готовится";
                        break;
                    case "Готов":
                        statusText = "готов к выдаче";
                        break;
                    default:
                        statusText = order.Status;
                        break;
                }

                DialogResult result = MessageBox.Show(
                    $"Вы уверены, что хотите отменить заказ №{orderNumber}?\n\n" +
                    $"Текущий статус: {statusText}\n" +
                    $"Сумма заказа: {order.Total:F2} руб.\n\n" +
                    "Отмененный заказ будет перемещен в историю.",
                    "Подтверждение отмены",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (_db.CancelOrder(order.Id))
                    {
                        // Обновляем все представления
                        RefreshOrdersList();
                        RefreshKitchenView();
                        RefreshDisplay();

                        MessageBox.Show($"Заказ №{orderNumber} отменен!",
                            "Заказ отменен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при отмене заказа. Возможно, заказ уже завершен.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Заказ не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDisplay()
        {
            flowLayoutPanelOrders.Controls.Clear();
            var orders = _db.GetAllOrders();

            if (orders.Count == 0)
            {
                Label noOrders = new Label
                {
                    Text = "Нет активных заказов",
                    ForeColor = Color.White,
                    Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold),
                    AutoSize = true,
                    BackColor = Color.Black
                };
                flowLayoutPanelOrders.Controls.Add(noOrders);
                return;
            }

            // Исключаем завершенные и отмененные заказы
            var activeOrders = orders.Where(o => o.Status != "Завершен" && o.Status != "Отменен")
                                      .OrderBy(o => o.OrderNumber);

            foreach (var order in activeOrders)
            {
                Panel orderPanel = new Panel();
                orderPanel.Width = 320;
                orderPanel.Height = 260;
                orderPanel.BorderStyle = BorderStyle.FixedSingle;
                orderPanel.Margin = new Padding(15);

                switch (order.Status)
                {
                    case "Ожидает":
                        orderPanel.BackColor = Color.Gold;
                        break;
                    case "В работе":
                        orderPanel.BackColor = Color.LightBlue;
                        break;
                    case "Готов":
                        orderPanel.BackColor = Color.LightGreen;
                        break;
                    default:
                        orderPanel.BackColor = Color.LightGray;
                        break;
                }

                Panel numberPanel = new Panel();
                numberPanel.Dock = DockStyle.Top;
                numberPanel.Height = 55;
                numberPanel.BackColor = Color.Transparent;

                Label lblOrderNumber = new Label();
                lblOrderNumber.Text = $"ЗАКАЗ №{order.OrderNumber}";
                lblOrderNumber.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
                lblOrderNumber.Dock = DockStyle.Fill;
                lblOrderNumber.TextAlign = ContentAlignment.MiddleCenter;
                lblOrderNumber.BackColor = Color.Transparent;
                numberPanel.Controls.Add(lblOrderNumber);

                Panel statusPanel = new Panel();
                statusPanel.Dock = DockStyle.Fill;
                statusPanel.BackColor = Color.Transparent;

                Label lblStatus = new Label();
                string statusText = "";
                switch (order.Status)
                {
                    case "Ожидает":
                        statusText = "В ОЖИДАНИИ";
                        break;
                    case "В работе":
                        statusText = "ГОТОВИТСЯ";
                        break;
                    case "Готов":
                        statusText = "ГОТОВ!";
                        break;
                }
                lblStatus.Text = statusText;
                lblStatus.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Bold);
                lblStatus.ForeColor = Color.Black;
                lblStatus.Dock = DockStyle.Fill;
                lblStatus.TextAlign = ContentAlignment.MiddleCenter;
                lblStatus.BackColor = Color.Transparent;
                statusPanel.Controls.Add(lblStatus);

                Panel itemsPanel = new Panel();
                itemsPanel.Dock = DockStyle.Bottom;
                itemsPanel.Height = 110;
                itemsPanel.BackColor = Color.Transparent;

                Label lblItems = new Label();
                string itemsText = string.Join("\n", order.Items.Select(i => $"{i.Name} x{i.Quantity}"));
                if (order.Items.Count > 4)
                {
                    itemsText = string.Join("\n", order.Items.Take(4).Select(i => $"{i.Name} x{i.Quantity}")) + $"\n... и еще {order.Items.Count - 4}";
                }
                lblItems.Text = itemsText;
                lblItems.Font = new Font("Microsoft Sans Serif", 10F);
                lblItems.Dock = DockStyle.Fill;
                lblItems.TextAlign = ContentAlignment.MiddleCenter;
                lblItems.BackColor = Color.Transparent;
                itemsPanel.Controls.Add(lblItems);

                orderPanel.Controls.Add(statusPanel);
                orderPanel.Controls.Add(itemsPanel);
                orderPanel.Controls.Add(numberPanel);

                flowLayoutPanelOrders.Controls.Add(orderPanel);
            }
        }

        private void BtnRefreshOrders_Click(object sender, EventArgs e)
        {
            RefreshOrdersList();
            RefreshKitchenView();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            dataGridViewHistory.Rows.Clear();

            DateTime start = dateTimePickerStart.Value.Date;
            DateTime end = dateTimePickerEnd.Value.Date.AddDays(1);
            string statusFilter = comboBoxStatusFilter.SelectedItem?.ToString();

            var orders = _db.GetAllOrders();
            var filteredOrders = orders.Where(o => o.OrderTime >= start && o.OrderTime < end);

            if (statusFilter != "Все")
            {
                filteredOrders = filteredOrders.Where(o => o.Status == statusFilter);
            }

            foreach (var order in filteredOrders)
            {
                TimeSpan? timeSpent = null;
                if (order.ReadyTime.HasValue)
                {
                    timeSpent = order.ReadyTime.Value - order.OrderTime;
                }

                dataGridViewHistory.Rows.Add(
                    order.OrderNumber,
                    order.OrderTime.ToString("dd.MM.yyyy HH:mm"),
                    order.Status,
                    timeSpent.HasValue ? $"{timeSpent.Value.Minutes} мин" : "-",
                    $"{order.Total:F2} руб."
                );
            }

            if (filteredOrders.Count() == 0)
            {
                MessageBox.Show("Заказы по выбранным критериям не найдены", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (dataGridViewHistory.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV файлы (*.csv)|*.csv";
            saveFileDialog.Title = "Экспорт истории заказов";
            saveFileDialog.FileName = $"OrdersHistory_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show($"Данные экспортированы в файл: {saveFileDialog.FileName}",
                    "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnSaveMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtItemName.Text) && numericPrice.Value > 0)
            {
                string category = comboBoxCategory.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(category))
                {
                    MessageBox.Show("Пожалуйста, выберите категорию", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!menuItems.Any(m => m.Name.Equals(txtItemName.Text, StringComparison.OrdinalIgnoreCase)))
                {
                    if (_db.AddMenuItem(txtItemName.Text, category, numericPrice.Value))
                    {
                        LoadMenuFromDatabase();

                        MessageBox.Show($"Позиция меню \"{txtItemName.Text}\" добавлена в категорию \"{category}\"",
                            "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearMenuItemForm();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при добавлении позиции", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Такая позиция уже существует", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Введите название блюда и цену", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnUpdateMenuItem_Click(object sender, EventArgs e)
        {
            if (!selectedMenuItemId.HasValue)
            {
                MessageBox.Show("Пожалуйста, выберите блюдо для редактирования",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtItemName.Text) || numericPrice.Value <= 0)
            {
                MessageBox.Show("Введите корректное название блюда и цену",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string category = comboBoxCategory.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Пожалуйста, выберите категорию",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверяем, не существует ли уже блюдо с таким именем (кроме текущего)
            var existingItem = menuItems.FirstOrDefault(m =>
                m.Name.Equals(txtItemName.Text, StringComparison.OrdinalIgnoreCase) &&
                m.Id != selectedMenuItemId.Value);

            if (existingItem != null)
            {
                MessageBox.Show("Блюдо с таким названием уже существует",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Обновить блюдо \"{txtItemName.Text}\"?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (_db.UpdateMenuItem(selectedMenuItemId.Value, txtItemName.Text, category, numericPrice.Value))
                {
                    // Полностью перезагружаем меню из базы
                    LoadMenuFromDatabase();

                    MessageBox.Show("Блюдо успешно обновлено!",
                        "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearMenuItemForm();
                }
                else
                {
                    MessageBox.Show("Ошибка при обновлении блюда",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void BtnDeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (!selectedMenuItemId.HasValue)
            {
                MessageBox.Show("Пожалуйста, выберите блюдо для удаления",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = menuItems.FirstOrDefault(m => m.Id == selectedMenuItemId.Value);
            if (item == null)
            {
                MessageBox.Show("Блюдо не найдено",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Вы уверены, что хотите удалить блюдо \"{item.Name}\"?\n\n" +
                "Внимание: Если это блюдо использовалось в заказах, удаление будет невозможно.",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (_db.DeleteMenuItem(selectedMenuItemId.Value))
                {
                    // Полностью перезагружаем меню из базы
                    LoadMenuFromDatabase();

                    MessageBox.Show("Блюдо успешно удалено!",
                        "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearMenuItemForm();
                }
                else
                {
                    MessageBox.Show(
                        "Невозможно удалить блюдо, так как оно используется в существующих заказах.\n\n" +
                        "Рекомендуется вместо удаления сделать блюдо недоступным.",
                        "Невозможно удалить",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        private void ClearMenuItemForm()
        {
            selectedMenuItemId = null;
            txtItemName.Clear();
            numericPrice.Value = 0;
            comboBoxCategory.SelectedIndex = 0;

            btnSaveMenuItem.Enabled = true;
            btnUpdateMenuItem.Enabled = false;
            btnDeleteMenuItem.Enabled = false;

            labelItemName.Text = "Название блюда:";
            groupBoxMenuItemDetails.Text = "Детали позиции";

            txtItemName.Focus();
        }

        private void BtnAddMenuItem_Click(object sender, EventArgs e)
        {
            ClearMenuItemForm();
        }

        // ==================== УПРАВЛЕНИЕ ПОЛЬЗОВАТЕЛЯМИ ====================

        private void DataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewUsers.Rows[e.RowIndex];
                selectedUserId = (int)row.Cells[0].Value;
                txtUsername.Text = row.Cells[1].Value?.ToString();
                string role = row.Cells[2].Value?.ToString();

                if (role != null)
                {
                    int index = comboBoxRole.Items.IndexOf(role);
                    if (index >= 0) comboBoxRole.SelectedIndex = index;
                }

                txtPassword.Clear();
                // Используем Tag для хранения информации о том, что это редактирование
                txtPassword.Tag = "edit";
                txtPassword.Text = "";

                btnSaveUser.Enabled = false;
                btnUpdateUser.Enabled = true;
                btnDeleteUser.Enabled = true;

                groupBoxUserDetails.Text = "Редактирование пользователя";
            }
        }

        private void DataGridViewUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewUsers_CellClick(sender, e);
        }

        private void BtnSaveUser_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUsername.Text) &&
                !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                string role = comboBoxRole.SelectedItem?.ToString();
                if (_db.AddUser(txtUsername.Text, txtPassword.Text, role))
                {
                    LoadUsersFromDatabase();
                    MessageBox.Show("Пользователь сохранен", "Успешно",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearUserForm();
                }
                else
                {
                    MessageBox.Show("Пользователь с таким именем уже существует", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля (имя и пароль)", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnUpdateUser_Click(object sender, EventArgs e)
        {
            if (!selectedUserId.HasValue)
            {
                MessageBox.Show("Пожалуйста, выберите пользователя для редактирования",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Введите имя пользователя",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = comboBoxRole.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Пожалуйста, выберите роль",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверяем, не существует ли уже пользователь с таким именем (кроме текущего)
            var users = _db.GetAllUsers();
            var existingUser = users.FirstOrDefault(u =>
                u.Username.Equals(txtUsername.Text, StringComparison.OrdinalIgnoreCase) &&
                u.Id != selectedUserId.Value);

            if (existingUser != null)
            {
                MessageBox.Show("Пользователь с таким именем уже существует",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Обновить пользователя \"{txtUsername.Text}\"?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string password = txtPassword.Text.Trim();
                // Если пароль пустой - не меняем его
                if (string.IsNullOrEmpty(password))
                {
                    password = null;
                }
                if (_db.UpdateUser(selectedUserId.Value, txtUsername.Text, password, role))
                {
                    LoadUsersFromDatabase();
                    MessageBox.Show("Пользователь успешно обновлен!",
                        "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearUserForm();
                }
                else
                {
                    MessageBox.Show("Ошибка при обновлении пользователя",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            if (!selectedUserId.HasValue)
            {
                MessageBox.Show("Пожалуйста, выберите пользователя для удаления",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = _db.GetAllUsers().FirstOrDefault(u => u.Id == selectedUserId.Value);
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (user.Username == "admin")
            {
                MessageBox.Show("Нельзя удалить администратора по умолчанию",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Вы уверены, что хотите удалить пользователя \"{user.Username}\"?\n\n" +
                "Это действие необратимо.",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (_db.DeleteUser(selectedUserId.Value))
                {
                    LoadUsersFromDatabase();
                    MessageBox.Show("Пользователь успешно удален!",
                        "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearUserForm();
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении пользователя",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void ClearUserForm()
        {
            selectedUserId = null;
            txtUsername.Clear();
            txtPassword.Clear();
            comboBoxRole.SelectedIndex = 0;

            btnSaveUser.Enabled = true;
            btnUpdateUser.Enabled = false;
            btnDeleteUser.Enabled = false;

            groupBoxUserDetails.Text = "Добавление пользователя";

            txtUsername.Focus();
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            ClearUserForm();
        }

        // ==================== ОТЧЕТЫ ====================

        private void GenerateReport(string title, string content)
        {
            richTextBoxReport.Clear();
            richTextBoxReport.Text = $"{title}\n{new string('-', 50)}\n{content}\n\n" +
                $"{new string('-', 50)}\n" +
                $"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm:ss}\n" +
                $"Система учета заказов в кафе";
        }

        private void BtnSalesReport_Click(object sender, EventArgs e)
        {
            decimal totalRevenue = _db.GetTotalRevenue();
            int totalOrders = _db.GetCompletedOrdersCount();
            decimal avgCheck = totalOrders > 0 ? totalRevenue / totalOrders : 0;

            GenerateReport("Отчет по продажам",
                $"Общая выручка: {totalRevenue:F2} руб.\n" +
                $"Количество заказов: {totalOrders}\n" +
                $"Средний чек: {avgCheck:F2} руб.");
        }

        private void BtnPopularItemsReport_Click(object sender, EventArgs e)
        {
            var popularItems = _db.GetPopularItems(5);

            if (popularItems.Count == 0)
            {
                GenerateReport("Популярные блюда", "Нет данных о заказах");
                return;
            }

            string content = "Популярные блюда:\n";
            int rank = 1;
            foreach (var item in popularItems)
            {
                content += $"{rank++}. {item.Key} - {item.Value} шт.\n";
            }

            GenerateReport("Популярные блюда", content);
        }

        private void BtnCookingTimeReport_Click(object sender, EventArgs e)
        {
            double avgTime = _db.GetAverageCookingTime();
            int completedOrders = _db.GetCompletedOrdersCount();

            if (completedOrders > 0)
            {
                GenerateReport("Время приготовления",
                    $"Среднее время приготовления: {avgTime:F0} минут\n" +
                    $"Всего выполнено заказов: {completedOrders}");
            }
            else
            {
                GenerateReport("Время приготовления", "Нет завершенных заказов");
            }
        }

        private void BtnShiftReport_Click(object sender, EventArgs e)
        {
            int todayOrders = _db.GetCompletedOrdersCount(DateTime.Today, DateTime.Today);
            decimal revenue = _db.GetTotalRevenue(DateTime.Today, DateTime.Today);
            double avgTime = _db.GetAverageCookingTime();

            GenerateReport("Отчет по смене",
                $"Дата: {DateTime.Now:dd.MM.yyyy}\n" +
                $"Выручка: {revenue:F2} руб.\n" +
                $"Количество заказов: {todayOrders}\n" +
                $"Среднее время ожидания: {(avgTime > 0 ? $"{avgTime:F0}" : "—")} мин");
        }


        private void ChangeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var loginForm = new Forms.LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Система учета заказов в кафе\nВерсия 3.0\nСамообслуживание\n\n" +
                "Клиент видит готовые заказы на мониторе и забирает самостоятельно\n\n" +
                "Цвета статусов на мониторе:\n" +
                "Желтый - заказ ожидает\n" +
                "Синий - заказ готовится\n" +
                "Зеленый - заказ готов!\n\n" +
                "Категории блюд:\n" +
                "• Напитки\n" +
                "• Закуски\n" +
                "• Салаты\n" +
                "• Горячие блюда\n" +
                "• Десерты\n\n" +
                "Для завершения заказа:\n" +
                "1. Выберите заказ в списке 'Активные заказы'\n" +
                "2. Нажмите кнопку 'Завершить заказ'\n\n" +
                "Для отмены заказа:\n" +
                "1. Выберите заказ в списке 'Активные заказы'\n" +
                "2. Нажмите кнопку 'Отменить заказ'",
                "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RefreshAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadMenuFromDatabase();
            RefreshOrdersList();
            RefreshKitchenView();
            RefreshDisplay();
            BtnSearch_Click(sender, e);
        }
    }
}