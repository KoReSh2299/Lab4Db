using Lab4.Models;

namespace Lab4.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Lab4DbContext context)
        {
            context.Database.EnsureCreated();

            if(!context.Clients.Any())
            {
                InitializeClients(context, 500);
            }

            if(!context.Cars.Any())
            {
                InitializeCars(context, 2000);
            }

            if(!context.ParkingSpaces.Any())
            {
                InitializeParkingSpaces(context, 100);
            }
        }

        private static void InitializeClients(Lab4DbContext context, int countEntities)
        {
            var surnames = new string[] { "Ермолаев","Журавлев","Зеленин","Грачёв","Дмитриев","Коршунов","Ковалёв",
                "Кузнецов","Тихонов","Осипов","Попов","Кузьмин","Котов"};

            var names = new string[] { "Александр","Вадим","Михаил","Владислав",
            "Владимир","Родион","Егор","Евгений",
            "Никита","Дмитрий","Серафим","Богдан",
            "Олег","Павел","Пётр","Алексей",
            "Антон","Василий","Максим","Руслан"};

            var middleNames = new string[] { "Макарович","Миронович","Алексеевич","Александрович",
            "Степанович","Кириллович","Ильинич","Артёмович",
            "Егорович","Матвеевич","Мирославович","Богданович",
            "Олегович","Павлович","Петрович","Алексеевич"};

            var random = new Random();

            for (int i = 0; i < countEntities; i++)
            {
                var randName = names[random.Next(names.Length)];
                var randSurname = surnames[random.Next(surnames.Length)];
                var randMiddleName = middleNames[random.Next(middleNames.Length)];

                context.Clients.Add(new Client() { Name = randName, MiddleName = randMiddleName, Surname = randSurname });
            }

            context.SaveChanges();
        }

        private static void InitializeCars(Lab4DbContext context, int countEntities)
        {
            var clients = context.Clients.ToList() ?? throw new ArgumentNullException("Таблица Клиенты не инициализирована");

            var brands = new string[] { "BMW","Volvo","Volkswagen","Toyota",
                                        "Skoda","Renault","Peugeot","Opel",
                                        "Nissan","LADA","KIA","Lexus",
                                        "Ford","Audi","Fiat","Chevrolet"};

            var random = new Random();

            for(int i = 0;i < countEntities; i++)
            {
                var randClientId = clients[random.Next(clients.Count)].Id;
                var randNumber = random.Next(100000000, 1000000000).ToString();
                var randBrand = brands[random.Next(brands.Length)];

                context.Cars.Add(new Car { Brand = randBrand, Number = randNumber, ClientId = randClientId});
            }

            context.SaveChanges();
        }

        private static void InitializeParkingSpaces(Lab4DbContext context, int countEntities)
        {
            var cars = context.Cars.ToList() ?? throw new ArgumentNullException("Таблица Cars не инициализирована");
            var unTakenCars = cars.ToList();

            var random = new Random();
            var countUnPenalties = (countEntities * 65) / 100;

            for(int i = 0; i < countEntities; i++)
            {
                var isTaken = random.Next(0, 2) == 1;
                Car takenCar = null;

                if(isTaken)
                {
                    takenCar = unTakenCars[random.Next(unTakenCars.Count)];
                    unTakenCars.Remove(takenCar);
                }

                if(i <= countUnPenalties)
                {
                    context.ParkingSpaces.Add(new ParkingSpace() { IsPenalty = false, Car = takenCar });
                }
                else
                {
                    context.ParkingSpaces.Add(new ParkingSpace() { IsPenalty = true, Car = takenCar });
                }
            }

            context.SaveChanges();
        }
    }
}
