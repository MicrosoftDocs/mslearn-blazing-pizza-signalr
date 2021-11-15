﻿namespace BlazingPizza.Client;

public class OrderState
{
    public bool ShowingConfigureDialog { get; private set; }

    public Pizza ConfiguringPizza { get; private set; } = default!;

    public Order Order { get; private set; } = new();

    public void ShowConfigurePizzaDialog(PizzaSpecial special)
    {
        ConfiguringPizza = new Pizza()
        {
            Special = special,
            SpecialId = special.Id,
            Size = Pizza.DefaultSize,
            Toppings = new List<PizzaTopping>(),
        };

        ShowingConfigureDialog = true;
    }

    public void CancelConfigurePizzaDialog()
    {
        ConfiguringPizza = null;
        ShowingConfigureDialog = false;
    }

    public void ConfirmConfigurePizzaDialog()
    {
        if (ConfiguringPizza is not null)
        {
            Order.Pizzas.Add(ConfiguringPizza);
            ConfiguringPizza = null;
        }

        ShowingConfigureDialog = false;
    }

    public void RemoveConfiguredPizza(Pizza pizza) => Order.Pizzas.Remove(pizza);

    public void ResetOrder() => Order = new Order();

    public void ReplaceOrder(Order order) => Order = order;
}
