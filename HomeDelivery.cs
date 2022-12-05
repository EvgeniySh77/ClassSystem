using System;

namespace ClassSystem
{
    class HomeDelivery : Delivery
    {        
        public HomeDelivery(string address) : base(address, deliveryTypes)
        {             
            this.address = address;    
        }

        public override void DeliverGoods()
        {
            Console.WriteLine("Ваш товар будет доставлен завтра, курьером на дом,");
            Console.WriteLine($"по адресу {address}");
            Console.WriteLine("Ожидайте курьера в течении дня, спасибо за заказ!!!");
        }
    }
}
