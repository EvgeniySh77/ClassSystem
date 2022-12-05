using System;

namespace ClassSystem
{
    class ShopDelivery : Delivery
    {        
        public ShopDelivery(string address) : base(address, deliveryTypes)
        {
            this.address = address;  
        }

        public override void DeliverGoods()
        {
            Console.WriteLine("Ваш товар будет доставлен завтра в магазин,");
            Console.WriteLine($"по адресу {address}");
            Console.WriteLine("Часы работы магазина с 10-00 до 20-00 часов, спасибо за заказ!!!");
        }
    }
}
