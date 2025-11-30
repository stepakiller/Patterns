using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public interface IOrder
    {
        double GetPrice();
        string GetDescription();
    }

    public class BaseOrder : IOrder
    {
        public double GetPrice() => 100.0;

        public string GetDescription() => "Базовый заказ";
    }

    public abstract class OrderDecorator : IOrder
    {
        protected IOrder _order;

        protected OrderDecorator(IOrder order) => _order = order;

        public virtual double GetPrice() => _order.GetPrice();

        public virtual string GetDescription() => _order.GetDescription();
    }

    public class ExpressDeliveryDecorator : OrderDecorator
    {
        public ExpressDeliveryDecorator(IOrder order) : base(order) { }

        public override double GetPrice() => _order.GetPrice() + 30.0;

        public override string GetDescription() => _order.GetDescription() + ", оперативная доставка";
    }

    public class GiftWrapDecorator : OrderDecorator
    {
        public GiftWrapDecorator(IOrder order) : base(order) { }

        public override double GetPrice() => _order.GetPrice() + 20.0;

        public override string GetDescription() => _order.GetDescription() + ", упаковка подарков";
    }

    public class DrinksDecorator : OrderDecorator
    {
        public DrinksDecorator(IOrder order) : base(order) { }

        public override double GetPrice() => _order.GetPrice() + 15.0;

        public override string GetDescription() => _order.GetDescription() + ", напитки";
    }
}
