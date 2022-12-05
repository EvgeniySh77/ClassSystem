using System;

namespace ClassSystem
{
    class PickPointDelivery : Delivery
    {        
        public PickPointDelivery(string address) : base(address, deliveryTypes)
        {
            this.address = address;  
        }

        public override void DeliverGoods()
        {
            Console.WriteLine("Ваш товар будет доставлен в течении 3-х дней,");
            Console.WriteLine($"в пункт самовывоза по адресу {address}");
            Console.WriteLine("Ожидайте сообщения по СМС или электронной почте, спасибо за заказ!!!");
        }
    }
}
