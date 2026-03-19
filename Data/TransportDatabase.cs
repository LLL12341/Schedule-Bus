using System.Collections.Generic;
using TransportWebSystem.Models;

namespace TransportWebSystem.Data
{
    public sealed class TransportDatabase
    {
        private static readonly TransportDatabase _instance = new TransportDatabase();
        public static TransportDatabase Instance => _instance;

        public List<Stop> Stops { get; private set; }
        public List<Transport> Routes { get; private set; }

        private TransportDatabase()
        {
            var maidan = new Stop { Id = 1, Name = "Майдан Незалежності", District = "Центр" };
            var teatralna = new Stop { Id = 2, Name = "Театральна площа", District = "Центр" };
            var pokrovskyi = new Stop { Id = 20, Name = "Покровський собор", District = "Центр" };
            var prospektMyru = new Stop { Id = 22, Name = "Проспект Миру", District = "Центр" };
            var drahomanova = new Stop { Id = 31, Name = "вул. Драгоманова", District = "Центр" };
            var tcViktoria = new Stop { Id = 30, Name = "ТЦ \"Вікторія\"", District = "Центр" };
            var istambul = new Stop { Id = 32, Name = "Істамбул", District = "Центр" };

            var avtovokzal = new Stop { Id = 3, Name = "Автовокзал", District = "Автовокзал та Мототрек" };
            var mototrek = new Stop { Id = 10, Name = "Мототрек", District = "Автовокзал та Мототрек" };
            var radiozavod = new Stop { Id = 26, Name = "Радіозавод", District = "Автовокзал та Мототрек" };
            var shkola12 = new Stop { Id = 6, Name = "12 школа", District = "Автовокзал та Мототрек" };

            var yuvileinyi = new Stop { Id = 7, Name = "Мікрорайон Ювілейний", District = "Ювілейний та Боярка" };
            var boyarka = new Stop { Id = 14, Name = "Боярка", District = "Ювілейний та Боярка" };
            var ekvator = new Stop { Id = 11, Name = "ТЦ Екватор", District = "Ювілейний та Боярка" };
            var lutskeKiltse = new Stop { Id = 12, Name = "Луцьке кільце", District = "Ювілейний та Боярка" };
            var rzva = new Stop { Id = 15, Name = "РЗВА", District = "Ювілейний та Боярка" };
            var onkodyspanser = new Stop { Id = 16, Name = "Онкодиспансер", District = "Ювілейний та Боярка" };
            var ahrarnyiKoledzh = new Stop { Id = 38, Name = "Аграрний коледж", District = "Ювілейний та Боярка" }; // НОВА ЗУПИНКА

            var pivnichnyi = new Stop { Id = 8, Name = "Мікрорайон Північний", District = "Північний та Льонокомбінат" };
            var lyonokombinat = new Stop { Id = 9, Name = "Льонокомбінат", District = "Північний та Льонокомбінат" };
            var chaika = new Stop { Id = 21, Name = "Чайка", District = "Північний та Льонокомбінат" };
            var bKhmelnytskoho = new Stop { Id = 25, Name = "бул. Богдана Хмельницького", District = "Північний та Льонокомбінат" };

            var vidinska = new Stop { Id = 24, Name = "вул. Відінська", District = "Відінська та Ст. Бандери" };
            var stepanaBandery = new Stop { Id = 29, Name = "вул. Степана Бандери", District = "Відінська та Ст. Бандери" };
            var bilyiLebid = new Stop { Id = 27, Name = "Магазин \"Білий Лебідь\"", District = "Відінська та Ст. Бандери" };
            var pobutradiotekhnika = new Stop { Id = 28, Name = "Побутрадіотехніка", District = "Відінська та Ст. Бандери" };
            var maidanMistHeroiv = new Stop { Id = 37, Name = "Майдан Міст-героїв України", District = "Відінська та Ст. Бандери" };

            var zaliznychnyi = new Stop { Id = 4, Name = "Залізничний вокзал", District = "Залізничний вокзал" };
            var zolotiyivska = new Stop { Id = 18, Name = "вул. Золотіївська", District = "Залізничний вокзал" };
            var rynok = new Stop { Id = 23, Name = "Ринок", District = "Залізничний вокзал" };

            var pyvzavod = new Stop { Id = 5, Name = "Пивзавод", District = "Пивзавод" };
            var budynokOfitseriv = new Stop { Id = 36, Name = "Будинок офіцерів", District = "Пивзавод" };

            var zoopark = new Stop { Id = 13, Name = "Зоопарк", District = "Передмістя та Інші" };
            var kvasyliv = new Stop { Id = 17, Name = "Квасилів", District = "Передмістя та Інші" };
            var kolodenka = new Stop { Id = 19, Name = "Колоденка", District = "Передмістя та Інші" };
            var enerhetykiv = new Stop { Id = 33, Name = "вул. Енергетиків", District = "Передмістя та Інші" };
            var rozvylka = new Stop { Id = 34, Name = "Розвилка", District = "Передмістя та Інші" };
            var trcFozzy = new Stop { Id = 35, Name = "ТРЦ Фоззі", District = "Передмістя та Інші" };


            Stops = new List<Stop> 
            { 
                maidan, teatralna, pokrovskyi, prospektMyru, drahomanova, tcViktoria, istambul,
                avtovokzal, mototrek, radiozavod, shkola12,
                yuvileinyi, boyarka, ekvator, lutskeKiltse, rzva, onkodyspanser, ahrarnyiKoledzh,
                pivnichnyi, lyonokombinat, chaika, bKhmelnytskoho,
                vidinska, stepanaBandery, bilyiLebid, pobutradiotekhnika, maidanMistHeroiv,
                zaliznychnyi, zolotiyivska, rynok,
                pyvzavod, budynokOfitseriv,
                zoopark, kvasyliv, kolodenka, enerhetykiv, rozvylka, trcFozzy
            };

            TransportFactory busFactory = new BusFactory();
            TransportFactory trolleybusFactory = new TrolleybusFactory();

            var tr1 = trolleybusFactory.CreateTransport("1 (Мототрек - Ювілейний)");
            tr1.Stops = new List<Stop> { mototrek, bilyiLebid, pobutradiotekhnika, stepanaBandery, vidinska, shkola12, teatralna, maidan, budynokOfitseriv, pyvzavod, yuvileinyi };

            var tr2 = trolleybusFactory.CreateTransport("2 (Боярка - Льонокомбінат)");
            tr2.Stops = new List<Stop> { boyarka, ahrarnyiKoledzh, pyvzavod, prospektMyru, chaika, bKhmelnytskoho, maidan, lyonokombinat }; 

            var tr3 = trolleybusFactory.CreateTransport("3 (Мототрек - Залізничний вокзал)");
            tr3.Stops = new List<Stop> { mototrek, radiozavod, avtovokzal, pokrovskyi, maidan, shkola12, rynok, zaliznychnyi }; 

            var tr4a = trolleybusFactory.CreateTransport("4а (Мототрек - Льонокомбінат)");
            tr4a.Stops = new List<Stop> { mototrek, radiozavod, avtovokzal, lyonokombinat };

            var tr5 = trolleybusFactory.CreateTransport("5 (РЗВА - Мототрек)");
            tr5.Stops = new List<Stop> { rzva, pyvzavod, maidan, pokrovskyi, avtovokzal, mototrek };

            var tr7 = trolleybusFactory.CreateTransport("7 (Боярка - Північний)");
            tr7.Stops = new List<Stop> { boyarka, ahrarnyiKoledzh, shkola12, maidan, chaika, bKhmelnytskoho, pivnichnyi }; 

            var tr9a = trolleybusFactory.CreateTransport("9а (Мототрек - Північний)");
            tr9a.Stops = new List<Stop> { mototrek, radiozavod, avtovokzal, pivnichnyi };

            var tr10 = trolleybusFactory.CreateTransport("10 (Мототрек - Ювілейний через Автовокзал)");
            tr10.Stops = new List<Stop> { mototrek, radiozavod, avtovokzal, pokrovskyi, maidan, budynokOfitseriv, pyvzavod, yuvileinyi };

            var tr11 = trolleybusFactory.CreateTransport("11 (Енергетиків - Північний)");
            tr11.Stops = new List<Stop> { radiozavod, rozvylka, trcFozzy, enerhetykiv, ahrarnyiKoledzh, maidan, pivnichnyi }; 

            var tr12 = trolleybusFactory.CreateTransport("12 (Північний - Луцьке кільце)");
            tr12.Stops = new List<Stop> { pivnichnyi, maidan, budynokOfitseriv, lutskeKiltse };


            var bus1 = busFactory.CreateTransport("1 (Льонокомбінат - Ювілейне)");
            bus1.Stops = new List<Stop> { lyonokombinat, maidan, budynokOfitseriv, pyvzavod, shkola12, yuvileinyi };

            var bus3 = busFactory.CreateTransport("3 (Новодвірська - Князя Романа)");
            bus3.Stops = new List<Stop> { avtovokzal, mototrek };

            var bus4 = busFactory.CreateTransport("4 (Ювілейне - вул. Енергетиків)");
            bus4.Stops = new List<Stop> { yuvileinyi, ahrarnyiKoledzh, drahomanova, tcViktoria, istambul, maidan, budynokOfitseriv, pobutradiotekhnika, stepanaBandery, vidinska, rozvylka, trcFozzy, enerhetykiv };

            var bus6 = busFactory.CreateTransport("6 (Волинської Дивізії - вул. Корольова)");
            bus6.Stops = new List<Stop> { lyonokombinat, maidan, budynokOfitseriv };

            var bus7 = busFactory.CreateTransport("7 (Луцьке кільце - Зоопарк)");
            bus7.Stops = new List<Stop> { avtovokzal, maidan, budynokOfitseriv, zoopark };

            var bus34 = busFactory.CreateTransport("34 (Зоопарк - Залізничний вокзал)");
            bus34.Stops = new List<Stop> { zoopark, avtovokzal, chaika, prospektMyru, zaliznychnyi };

            var bus35 = busFactory.CreateTransport("35 (Волинської Дивізії - Луцьке Кільце)");
            bus35.Stops = new List<Stop> { boyarka, bKhmelnytskoho, maidan, budynokOfitseriv }; 

            var bus38 = busFactory.CreateTransport("38 (Агроресурс - Коновальця)");
            bus38.Stops = new List<Stop> { avtovokzal, bKhmelnytskoho, budynokOfitseriv }; 
            
            var bus45 = busFactory.CreateTransport("45 (вул. Князя Романа - Школа №19)");
            bus45.Stops = new List<Stop> { ahrarnyiKoledzh };

            var bus46 = busFactory.CreateTransport("46 (Квасилів - вул. Золотіївська)");
            bus46.Stops = new List<Stop> { kvasyliv, maidan, budynokOfitseriv, drahomanova, tcViktoria, istambul, teatralna, rynok, zaliznychnyi, zolotiyivska };

            var bus47 = busFactory.CreateTransport("47 (Вересневе - Льонокомбінат)");
            bus47.Stops = new List<Stop> { avtovokzal, pokrovskyi, maidan, budynokOfitseriv, shkola12, ahrarnyiKoledzh, bKhmelnytskoho, lyonokombinat };

            var bus47a = busFactory.CreateTransport("47А (Тинне - Льонокомбінат)");
            bus47a.Stops = new List<Stop> { ahrarnyiKoledzh, lyonokombinat }; 

            var bus53 = busFactory.CreateTransport("53 (НВО Потенціал - Вербова)");
            bus53.Stops = new List<Stop> { avtovokzal, pokrovskyi, maidan, budynokOfitseriv, pyvzavod, ahrarnyiKoledzh, boyarka, ekvator };

            var bus56 = busFactory.CreateTransport("56 (Чайка - Залізничний вокзал)");
            bus56.Stops = new List<Stop> { lyonokombinat, bKhmelnytskoho, chaika, maidan, budynokOfitseriv, zaliznychnyi };

            var bus57 = busFactory.CreateTransport("57 (Льонокомбінат - ПМК 100)");
            bus57.Stops = new List<Stop> { bKhmelnytskoho, rozvylka, trcFozzy, radiozavod }; 

            var bus61 = busFactory.CreateTransport("61 (Новодвірська - Ювілейне)");
            bus61.Stops = new List<Stop> { maidan, budynokOfitseriv, drahomanova, tcViktoria, yuvileinyi };

            var bus64 = busFactory.CreateTransport("64 (Колоденка - Залізничний вокзал)");
            bus64.Stops = new List<Stop> { kolodenka, rozvylka, trcFozzy, radiozavod, maidan, budynokOfitseriv, zaliznychnyi };

            var bus66 = busFactory.CreateTransport("66 (Червоні Гори - Онкодиспансер)");
            bus66.Stops = new List<Stop> { onkodyspanser, ahrarnyiKoledzh, rozvylka, trcFozzy, maidan, budynokOfitseriv, pyvzavod, yuvileinyi };

            Routes = new List<Transport>
            {
                tr1, tr2, tr3, tr4a, tr5, tr7, tr9a, tr10, tr11, tr12,
                bus1, bus3, bus4, bus6, bus7, bus34, bus35, bus38, bus45, bus46, bus47, bus47a, bus53, bus56, bus57, bus61, bus64, bus66
            };
        }
    }
}