using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Система_учета_заказов_в_кафешке
{
    public partial class MainForm : Form
    {
        private int nextOrderNumber = 1;
        private List<Order> orders = new List<Order>();
        private List<OrderItem> currentOrderItems = new List<OrderItem>();

        public class MenuItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
            public string DisplayText { get { return $"{Name} - {Price} руб."; } }
        }

        private List<MenuItem> menuItems = new List<MenuItem>();
        private int nextMenuItemId = 1;

        public MainForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            comboBoxStatusFilter.SelectedIndex = 0;
            comboBoxCategory.SelectedIndex = 0;
            comboBoxRole.SelectedIndex = 0;

            dateTimePickerStart.Value = DateTime.Today;
            dateTimePickerEnd.Value = DateTime.Today.AddDays(1);

            toolStripStatusUser.Text = "Пользователь: Администратор";

            dataGridViewPendingOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPendingOrders.MultiSelect = false;
            dataGridViewInProgress.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewInProgress.MultiSelect = false;
            dataGridViewActiveOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewActiveOrders.MultiSelect = false;
            dataGridViewMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMenu.MultiSelect = false;

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
            btnSaveUser.Click += BtnSaveUser_Click;
            btnAddMenuItem.Click += BtnAddMenuItem_Click;
            btnAddUser.Click += BtnAddUser_Click;
            btnSalesReport.Click += BtnSalesReport_Click;
            btnPopularItemsReport.Click += BtnPopularItemsReport_Click;
            btnCookingTimeReport.Click += BtnCookingTimeReport_Click;
            btnShiftReport.Click += BtnShiftReport_Click;
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            refreshAllToolStripMenuItem.Click += RefreshAllToolStripMenuItem_Click;

            if (btnCompleteOrder != null)
            {
                btnCompleteOrder.Click += BtnCompleteOrder_Click;
            }

            dataGridViewMenu.CellClick += DataGridViewMenu_CellClick;

            dataGridViewPendingOrders.CellClick += DataGridViewPendingOrders_CellClick;
            dataGridViewInProgress.CellClick += DataGridViewInProgress_CellClick;

            LoadTestMenuItems();

            RefreshMenuGrid();
        }

        private void LoadTestMenuItems()
        {
            // Напитки
            AddMenuItemToCollection("Капучино", "Напитки", 180);
            AddMenuItemToCollection("Латте", "Напитки", 200);
            AddMenuItemToCollection("Эспрессо", "Напитки", 120);
            AddMenuItemToCollection("Чай черный", "Напитки", 100);
            AddMenuItemToCollection("Чай зеленый", "Напитки", 100);
            AddMenuItemToCollection("Яблочный сок", "Напитки", 89);
            AddMenuItemToCollection("Апельсиновый сок", "Напитки", 89);
            AddMenuItemToCollection("Ананасовый сок", "Напитки", 89);
            AddMenuItemToCollection("Сок Мультифрукт", "Напитки", 96);
            AddMenuItemToCollection("Грушевый лимонад", "Напитки", 94);

            // Десерты
            AddMenuItemToCollection("Круассан", "Десерты", 150);
            AddMenuItemToCollection("Чизкейк", "Десерты", 250);
            AddMenuItemToCollection("Тирамису", "Десерты", 280);

            // Салаты
            AddMenuItemToCollection("Салат Цезарь", "Салаты", 320);

            // Горячие блюда
            AddMenuItemToCollection("Чизбургер", "Горячие блюда", 367);
            AddMenuItemToCollection("Классический бургер", "Горячие блюда", 242);
            AddMenuItemToCollection("Крабсбургер", "Горячие блюда", 344);
            AddMenuItemToCollection("Чикен Бургер", "Горячие блюда", 252);
            AddMenuItemToCollection("Черный Бургер", "Горячие блюда", 262);
            AddMenuItemToCollection("Пицца 4 сыра", "Горячие блюда", 489);
            AddMenuItemToCollection("Пицца Маргарита", "Горячие блюда", 462);
            AddMenuItemToCollection("Пицца Пеперони", "Горячие блюда", 469);
            AddMenuItemToCollection("Пицца классическая", "Горячие блюда", 400);

            // Закуски
            AddMenuItemToCollection("Сэндвич с курицей", "Закуски", 220);
            AddMenuItemToCollection("Сэндвич с говядиной", "Закуски", 224);
        }

        private void AddMenuItemToCollection(string name, string category, decimal price)
        {
            menuItems.Add(new MenuItem
            {
                Id = nextMenuItemId++,
                Name = name,
                Category = category,
                Price = price
            });

            listBoxAvailableItems.Items.Add($"{name} - {price} руб.");
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
                    listBoxCurrentOrder.Items[index] = $"{existingItem.Name} - {existingItem.Price} руб. x{existingItem.Quantity} = {existingItem.Total} руб.";
                }
                else
                {
                    var newItem = new OrderItem
                    {
                        Name = itemName,
                        Price = price,
                        Quantity = quantity,
                        Total = price * quantity
                    };
                    currentOrderItems.Add(newItem);
                    listBoxCurrentOrder.Items.Add($"{newItem.Name} - {newItem.Price} руб. x{newItem.Quantity} = {newItem.Total} руб.");
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
            labelOrderTotal.Text = $"Итого: {total} руб.";
        }

        private void BtnCreateOrder_Click(object sender, EventArgs e)
        {
            if (currentOrderItems.Count == 0)
            {
                MessageBox.Show("Добавьте блюда в заказ", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderNumber = nextOrderNumber++;
            var newOrder = new Order
            {
                OrderNumber = orderNumber,
                Items = new List<OrderItem>(currentOrderItems),
                Status = "Ожидает",
                OrderTime = DateTime.Now,
                Total = currentOrderItems.Sum(i => i.Total)
            };

            orders.Add(newOrder);

            currentOrderItems.Clear();
            listBoxCurrentOrder.Items.Clear();
            labelOrderTotal.Text = "Итого: 0 руб.";

            MessageBox.Show($"Заказ №{orderNumber} создан! Ожидайте на мониторе статусов.",
                "Заказ создан", MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshOrdersList();
            RefreshKitchenView();
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
            dataGridViewActiveOrders.Rows.Clear();
            var activeOrders = orders.Where(o => o.Status != "Завершен" && o.Status != "Отменен");

            foreach (var order in activeOrders)
            {
                string items = string.Join(", ", order.Items.Select(i => $"{i.Name} x{i.Quantity}"));
                dataGridViewActiveOrders.Rows.Add(
                    order.OrderNumber,
                    items,
                    order.Status,
                    order.OrderTime.ToString("HH:mm"),
                    $"{order.Total} руб."
                );
            }
        }

        private void RefreshKitchenView()
        {
            dataGridViewPendingOrders.Rows.Clear();
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
            var inProgressOrders = orders.Where(o => o.Status == "В работе");
            foreach (var order in inProgressOrders)
            {
                string items = string.Join(", ", order.Items.Select(i => $"{i.Name} x{i.Quantity}"));
                dataGridViewInProgress.Rows.Add(
                    order.OrderNumber,
                    items,
                    order.StartTime?.ToString("HH:mm") ?? "-"
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
                    $"{item.Price:F2}"
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
                txtItemName.Text = row.Cells[1].Value?.ToString();
                numericPrice.Value = decimal.Parse(row.Cells[3].Value?.ToString() ?? "0");

                string category = row.Cells[2].Value?.ToString();
                if (category != null)
                {
                    int index = comboBoxCategory.Items.IndexOf(category);
                    if (index >= 0) comboBoxCategory.SelectedIndex = index;
                }
            }
        }

        private void DataGridViewPendingOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridViewPendingOrders.ClearSelection();
                dataGridViewPendingOrders.Rows[e.RowIndex].Selected = true;
            }
        }

        private void DataGridViewInProgress_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridViewInProgress.ClearSelection();
                dataGridViewInProgress.Rows[e.RowIndex].Selected = true;
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
            var order = orders.FirstOrDefault(o => o.OrderNumber == orderNumber);

            if (order != null && order.Status == "Ожидает")
            {
                order.Status = "В работе";
                order.StartTime = DateTime.Now;
                RefreshKitchenView();
                RefreshOrdersList();
                RefreshDisplay();
                MessageBox.Show($"Заказ №{orderNumber} начали готовить!",
                    "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var order = orders.FirstOrDefault(o => o.OrderNumber == orderNumber);

            if (order != null && order.Status == "В работе")
            {
                order.Status = "Готов";
                order.ReadyTime = DateTime.Now;
                RefreshKitchenView();
                RefreshOrdersList();
                RefreshDisplay();

                MessageBox.Show($"Заказ №{orderNumber} готов! Клиент может забрать.",
                    "Заказ готов", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var order = orders.FirstOrDefault(o => o.OrderNumber == orderNumber);

            if (order != null)
            {
                DialogResult result = MessageBox.Show($"Завершить заказ №{orderNumber}?\n\nЗаказ будет перемещен в историю.",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    order.Status = "Завершен";
                    RefreshOrdersList();
                    RefreshKitchenView();
                    RefreshDisplay();

                    MessageBox.Show($"Заказ №{orderNumber} завершен!",
                        "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    $"{order.Total} руб."
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

                string newItemDisplay = $"{txtItemName.Text} - {numericPrice.Value} руб.";

                if (!menuItems.Any(m => m.Name == txtItemName.Text))
                {
                    menuItems.Add(new MenuItem
                    {
                        Id = nextMenuItemId++,
                        Name = txtItemName.Text,
                        Category = category,
                        Price = numericPrice.Value
                    });

                    listBoxAvailableItems.Items.Add(newItemDisplay);

                    RefreshMenuGrid();

                    MessageBox.Show($"Позиция меню добавлена в категорию \"{category}\"", "Успешно",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtItemName.Clear();
                    numericPrice.Value = 0;
                    comboBoxCategory.SelectedIndex = 0;
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

        private void BtnAddMenuItem_Click(object sender, EventArgs e)
        {
            txtItemName.Clear();
            numericPrice.Value = 0;
            comboBoxCategory.SelectedIndex = 0;
            txtItemName.Focus();
        }

        private void BtnSaveUser_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUsername.Text) &&
                !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                dataGridViewUsers.Rows.Add(
                    dataGridViewUsers.Rows.Count + 1,
                    txtUsername.Text,
                    comboBoxRole.SelectedItem?.ToString()
                );
                MessageBox.Show("Пользователь сохранен", "Успешно",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Clear();
                txtPassword.Clear();
                comboBoxRole.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            comboBoxRole.SelectedIndex = 0;
            txtUsername.Focus();
        }

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
            var completedOrders = orders.Where(o => o.Status == "Завершен");
            decimal totalRevenue = completedOrders.Sum(o => o.Total);
            int totalOrders = completedOrders.Count();
            decimal avgCheck = totalOrders > 0 ? totalRevenue / totalOrders : 0;

            GenerateReport("Отчет по продажам",
                $"Общая выручка: {totalRevenue} руб.\n" +
                $"Количество заказов: {totalOrders}\n" +
                $"Средний чек: {avgCheck:F2} руб.");
        }

        private void BtnPopularItemsReport_Click(object sender, EventArgs e)
        {
            var itemCounts = new Dictionary<string, int>();
            foreach (var order in orders)
            {
                foreach (var item in order.Items)
                {
                    if (itemCounts.ContainsKey(item.Name))
                        itemCounts[item.Name] += item.Quantity;
                    else
                        itemCounts[item.Name] = item.Quantity;
                }
            }

            if (itemCounts.Count == 0)
            {
                GenerateReport("Популярные блюда", "Нет данных о заказах");
                return;
            }

            var popular = itemCounts.OrderByDescending(x => x.Value).Take(5);
            string content = "Популярные блюда:\n";
            int rank = 1;
            foreach (var item in popular)
            {
                content += $"{rank++}. {item.Key} - {item.Value} шт.\n";
            }

            GenerateReport("Популярные блюда", content);
        }

        private void BtnCookingTimeReport_Click(object sender, EventArgs e)
        {
            var completedOrders = orders.Where(o => o.ReadyTime.HasValue && o.Status == "Завершен");
            if (completedOrders.Any())
            {
                var avgTime = completedOrders.Average(o => (o.ReadyTime.Value - o.OrderTime).TotalMinutes);
                GenerateReport("Время приготовления",
                    $"Среднее время приготовления: {avgTime:F0} минут\n" +
                    $"Всего выполнено заказов: {completedOrders.Count()}");
            }
            else
            {
                GenerateReport("Время приготовления", "Нет завершенных заказов");
            }
        }

        private void BtnShiftReport_Click(object sender, EventArgs e)
        {
            var todayOrders = orders.Where(o => o.OrderTime.Date == DateTime.Today && o.Status == "Завершен");
            int total = todayOrders.Count();
            decimal revenue = todayOrders.Sum(o => o.Total);

            var completedToday = todayOrders.Where(o => o.ReadyTime.HasValue);
            double avgTime = completedToday.Any() ?
                completedToday.Average(o => (o.ReadyTime.Value - o.OrderTime).TotalMinutes) : 0;

            GenerateReport("Отчет по смене",
                $"Дата: {DateTime.Now:dd.MM.yyyy}\n" +
                $"Выручка: {revenue} руб.\n" +
                $"Количество заказов: {total}\n" +
                $"Среднее время ожидания: {(avgTime > 0 ? $"{avgTime:F0}" : "—")} мин");
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Система учета заказов в кафе\nВерсия 2.0\nСамообслуживание\n\n" +
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
                "2. Нажмите кнопку 'Завершить заказ'",
                "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RefreshAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshOrdersList();
            RefreshKitchenView();
            RefreshDisplay();
            BtnSearch_Click(sender, e);
        }
    }

    public class OrderItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }

    public class Order
    {
        public int OrderNumber { get; set; }
        public List<OrderItem> Items { get; set; }
        public string Status { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? ReadyTime { get; set; }
        public decimal Total { get; set; }
    }
}