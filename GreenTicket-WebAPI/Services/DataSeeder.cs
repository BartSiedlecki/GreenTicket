using GreenTicket_WebAPI.Entities;
using GreenTicket_WebAPI.Services.Helpers;
using Microsoft.EntityFrameworkCore;

namespace GreenTicket_WebAPI.Services
{
    public class DataSeeder
    {
        private readonly GreenTicketDbContext _context;

        public DataSeeder(GreenTicketDbContext context)
        {
            _context = context;
        }

        // DELETE FROM [Image]
        // DELETE FROM [Seat]
        // DELETE FROM [Row]
        // DELETE FROM [EventPerformer]
        // DELETE FROM [Performer]
        // DELETE FROM [Event]
        // DELETE FROM [Section]
        // DELETE FROM [Venue]
        // DELETE FROM [EventSubCategory]
        // DELETE FROM [EventCategory]

        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                if (!_context.EventCategories.Any())
                {
                    var eventCategories = getCategories();
                    _context.EventCategories.AddRange(eventCategories);
                    _context.SaveChanges();
                }

                if (!_context.Performers.Any())
                {
                    var performers = getPerformers();
                    _context.Performers.AddRange(performers);
                    _context.SaveChanges();
                }

                if (!_context.Cities.Any())
                {
                    var cities = getCities();
                    _context.Cities.AddRange(cities);
                    _context.SaveChanges();
                }

                if (!_context.Venues.Any())
                {
                    var venues = getVenues();
                    _context.Venues.AddRange(venues);
                    _context.SaveChanges();
                }

                if (!_context.Events.Any())
                {
                    var events = getEvents();
                    _context.Events.AddRange(events);
                    _context.SaveChanges();
                }
            }
        }

        private IEnumerable<Performer> getPerformers()
        {
            var performers = new List<Performer>()
            {
                new Performer() { Name = "Electric Callboy" },
                new Performer() { Name = "Sting" },
                new Performer() { Name = "Sanah" },
                new Performer() { Name = "Alpha Wolf" },
                new Performer() { Name = "King 810" },
                new Performer() { Name = "Ten56" },
                new Performer() { Name = "Xile" },
                new Performer() { Name = "Prof. Maciej Poliszewski" },
                new Performer() { Name = "Orion" },
                new Performer() { Name = "Zenon Martyniuk" },
                new Performer() { Name = "Kombi" },
                new Performer() { Name = "Zenek" },
                new Performer() { Name = "Wirujący Derwisze z bractwa Mawlawi" },
                new Performer() { Name = "Fisz" },
                new Performer() { Name = "Emade" },
                new Performer() { Name = "Liroy" },
                new Performer() { Name = "Donald Churchill" },
                new Performer() { Name = "Peter Yeldhman" },
                new Performer() { Name = "Sukhishvili" },
                new Performer() { Name = "Metro" },
                new Performer() { Name = "Mistrzostwa Świata Super Enduro" },
                new Performer() { Name = "Hot Wheels Monster Trucks Live Glow Party" },
                new Performer() { Name = "Reprezentacja Polski w piłce nożnej" },
                new Performer() { Name = "Reprezentacja Albanii w piłce nożnej" },
                new Performer() { Name = "Reprezentacja Wysp Owczych w piłce nożnej" },
                new Performer() { Name = "Klub mężusiów" },
                };
            return performers;
        }

        private IEnumerable<EventCategory> getCategories()
        {
            var categories = new List<EventCategory>()
            {
                new EventCategory()
                {
                    Category = EventCategories.Concerts,
                    Title = "Concerts",
                    SubCategories = new List<EventSubCategory>() {
                        new EventSubCategory { Title = "Rock/Pop", Subcategory = EventSubcategories.RockPop },
                        new EventSubCategory { Title = "Hard/Heavy", Subcategory = EventSubcategories.HardHeavy },
                        new EventSubCategory { Title = "Classical music", Subcategory = EventSubcategories.ClassicalMusic },
                        new EventSubCategory { Title = "Electronic/Techno", Subcategory = EventSubcategories.ElectronicTechno },
                        new EventSubCategory { Title = "Disco/Dance", Subcategory = EventSubcategories.DiscoDance },
                        new EventSubCategory { Title = "Jazz", Subcategory = EventSubcategories.Jazz },
                        new EventSubCategory { Title = "Rap/Hip-Hop", Subcategory = EventSubcategories.RapHipHop },
                        new EventSubCategory { Title = "Others", Subcategory = EventSubcategories.OtherConcerts }
                    }
                },
                new EventCategory()
                {
                    Category = EventCategories.Culture,
                    Title = "Culture",
                    SubCategories = new List<EventSubCategory>() {
                        new EventSubCategory { Title = "Theatre", Subcategory = EventSubcategories.Theatre },
                        new EventSubCategory { Title = "Ballet/Dance", Subcategory = EventSubcategories.BalletDance },
                        new EventSubCategory { Title = "Musical", Subcategory = EventSubcategories.Musical },
                        new EventSubCategory { Title = "Others", Subcategory = EventSubcategories.OtherCulture }
                    }
                },
                new EventCategory()
                {
                    Category = EventCategories.Sport,
                    Title = "Sport",
                    SubCategories = new List<EventSubCategory>() {
                        new EventSubCategory { Title = "Handball", Subcategory = EventSubcategories.Handball },
                        new EventSubCategory { Title = "Football", Subcategory = EventSubcategories.Football },
                        new EventSubCategory { Title = "Vollayball", Subcategory = EventSubcategories.Vollayball },
                        new EventSubCategory { Title = "Motor sports", Subcategory = EventSubcategories.MotorSports },
                        new EventSubCategory { Title = "Bastekball", Subcategory = EventSubcategories.Bastekball },
                        new EventSubCategory { Title = "Others", Subcategory = EventSubcategories.OtherSport }
                    }
                },
                new EventCategory()
                {
                    Category = EventCategories.Other,
                    Title = "Other",
                    SubCategories = new List<EventSubCategory>() {
                        new EventSubCategory { Title = "Family", Subcategory = EventSubcategories.Family },
                        new EventSubCategory { Title = "Other", Subcategory = EventSubcategories.OtherOther }
                    }
                }


            };

            return categories;
        }

        private IEnumerable<City> getCities()
        {
            var cities = new List<City>()
            {
                new City () {Name = "Bydgoszcz" },
                new City () {Name = "Chorzów" },
                new City () {Name = "Gdańsk" },
                new City () {Name = "Gliwice" },
                new City () {Name = "Kraków" },
                new City () {Name = "Łódź" },
                new City () {Name = "Sopot" },
                new City () {Name = "Szczecin" },
                new City () {Name = "Toruń" },
                new City () {Name = "Warszawa" },
                new City () {Name = "Wrocław" }
            };

            return cities;
        }

        private IEnumerable<Venue> getVenues()
        {
            var venues = new List<Venue>()
            {
                new Venue ()
                {
                    Name = "B90",
                    Description = "B90 to największy klub koncertowy w Trójmieście, " +
                    "zlokalizowany na terenie byłej Stoczni Gdańskiej, w scenerii historycznych dźwigów, " +
                    "pochylni i obiektów przemysłowych. 10 min. od Centrum Starego Miasta przestrzeń o powierzchni 1700 m, " +
                    "posiadająca niezależną antresolę. To symbiotyczna, alternatywna przestrzeń dla sztuki niezależnej, " +
                    "sytuująca się w pełni surowym klimacie. To industrialny magazyn, zlokalizowany w niebanalnym miejscu, " +
                    "wypełniony wszechstronną przestrzenią dla muzyki.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "80-863",
                            CityID = getCityId("Gdańsk"),
                            Street = "Doki",
                            StreetNo = "1"
                        },
                    Capacity = 1200
                }
                ,
                new Venue ()
                {
                    Name = "Filharmonia im. Mieczysława Karłowicza w Szczecinie",
                    Description = "Bilety Filharmonii w Szczecinie pozwolą na spędzenie niezapomnianego czasu w otoczeniu najlepszej muzyki, " +
                    "która pozwoli zrelaksować się i oderwać na chwilę od codzienności. " +
                    "Koncerty Filharmonii Szczecin to propozycja doskonałej rozrywki na najwyższym poziomie, która na długo pozostanie w pamięci.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "70-515",
                            CityID = getCityId("Szczecin"),
                            Street = "Małopolska",
                            StreetNo = "48"
                        },
                    Capacity = 950
                },
                new Venue ()
                {
                    Name = "Narodowe Forum Muzyki we Wrocławiu",
                    Description = "Narodowe Forum Muzyki im. Witolda Lutosławskiego to instytucja kultury miasta Wrocławia, " +
                    "współprowadzona przez Ministra Kultury i Dziedzictwa Narodowego, Gminę Wrocław, Województwo Dolnośląskie, " +
                    "zarejestrowana w Rejestrze Instytucji Kultury Gminy Wrocław. " +
                    "Instytucja jest operatorem nowoczesnego wielofunkcyjnego gmachu koncertowego we Wrocławiu.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "50-071",
                            CityID = getCityId("Wrocław"),
                            Street = "plac Wolności",
                            StreetNo = "1"
                        },
                    Capacity = 1800
                },
                new Venue ()
                {
                    Name = "Parlament",
                    Description = "Klub Parlament to najbardziej rozpoznawalny klub w Trójmieście. " +
                    "Znajduje się przy ul. Świętego Ducha 2 w samym centrum Gdańska. Historia klubu sięga roku 2000, " +
                    "kiedy to rozpoczęła się przebudowa pomieszczeń dawnej stolarni Teatru Wybrzeże. " +
                    "Prace remontowe zakończyły się w listopadzie 2001 roku. " +
                    "To wtedy oficjalnie został otwarty największy i najnowocześniejszy klub muzyczny w Trójmieście.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "80-834",
                            CityID = getCityId("Gdańsk"),
                            Street = "Świętego Ducha",
                            StreetNo = "2"
                        },
                    Capacity = 650
                },
                new Venue ()
                {
                    Name = "Filharmonia Łódzka",
                    Description = "Nagrodzona Fryderykiem 2020 Filharmonia Łódzka im. Artura Rubinsteina jest jedną z najstarszych w Polsce. " +
                    "Orkiestra Symfoniczna FŁ została odznaczona Złotym Medalem Zasłużony Kulturze - Gloria Artis.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "90-135",
                            CityID = getCityId("Łódź"),
                            Street = "Prezydenta Gabriela Narutowicza",
                            StreetNo = "20/22"
                        },
                    Capacity = 658
                },
                new Venue ()
                {
                    Name = "Gdański Teatr Szekspirowski",
                    Description = "Gdański Teatr Szekspirowski jest jedynym teatrem szekspirowskim w Polsce. " +
                    "Powstał w miejscu, gdzie od początku XVII wieku funkcjonował budynek Szkoły Fechtunku – " +
                    "pierwszy publiczny teatr ówczesnej Rzeczypospolitej. " +
                    "Wyposażony w scenę typu elżbietańskiego i podobny do licznych teatrów angielskich epoki Elżbiety I, " +
                    "służył on zarówno do ćwiczeń i zawodów szermierczych, jak i do wystawiania przedstawień.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "85-070",
                            CityID = getCityId("Bydgoszcz"),
                            Street = "Marszałka Ferdynanda Focha",
                            StreetNo = "5"
                        },
                    Capacity = 687
                },
                new Venue ()
                {
                    Name = "Stadion Narodowy (PGE Narodowy)",
                    Description = "PGE Narodowy (dawniej Stadion Narodowy w Warszawie) to najnowocześniejsza arena wielofunkcyjna i " +
                    "jeden z najnowocześniejszych tego typu obiektów w Europie. W 2013 roku stał się najpopularniejszym miejscem w Polsce, " +
                    "przyciągając 1 milion 300 tys. gości w ciągu 12 miesięcy. Arena jest największym stadionem w Polsce.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "03-901",
                            CityID = getCityId("Warszawa"),
                            Street = "Al. Ks. J. Poniatowskiego",
                            StreetNo = "1"
                        },
                    Capacity = 58000
                },
                new Venue ()
                {
                    Name = "Atlas Arena",
                    Description = "Atlas Arena Łódź to jedna z większych hal widowiskowo-sportowych w Polsce, " +
                    "oddana do użytku w 2009 roku. Trybuny mogą pomieścić 10,4 tys. widzów, a na płycie można ustawić dodatkowo 3 tys. " +
                    "miejsc, do dyspozycji gości dostępnych jest 1500 miejsc postojowych, 4 ekrany multimedialne i 11 loży VIP-owskich (każda z tarasem).",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "94-020",
                            CityID = getCityId("Łódź"),
                            Street = "Al. ks. bp. Władysława Bandurskiego",
                            StreetNo = "7"
                        },
                    Capacity = 13806
                },
                new Venue ()
                {
                    Name = "Klub Hybrydy",
                    Description = "Jeden z najstarszych klubów studenckich w Polsce. „Hybrydy” działają z przerwami od końca lat 50. XX w. " +
                    "Przez wiele lat klub pełnił rolę centrum kultury studenckiej i matecznika artystycznego, z którego wyrosło wielu literatów, " +
                    "muzyków, twórców teatralnych i filmowych.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "00-019",
                            CityID = getCityId("Warszawa"),
                            Street = "Złota",
                            StreetNo = "7/9"
                        },
                    Capacity = 400
                },
                new Venue ()
                {
                    Name = "TAURON Arena Kraków",
                    Description = "TAURON Arena Kraków to największa i najnowocześniejsza hala widowiskowo-sportowa w Polsce, " +
                    "mogąca pomieścić 22 000 osób, pozwala na organizację wydarzeń o różnym charakterze i skali. " +
                    "Wśród nich są wydarzenia sportowe i kulturalne: koncerty, festiwale, pokazy filmowe, musicale, pokazy cyrkowe, " +
                    "show na lodzie; gale, kongresy, bankiety, imprezy branżowe i plenerowe.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "31-571",
                            CityID = getCityId("Kraków"),
                            Street = "Stanisława Lema",
                            StreetNo = "7"
                        },
                    Capacity = 13806
                },
                new Venue ()
                {
                    Name = "Progresja",
                    Description = "Klub Progresja Warszawa udostępnia artystom aż trzy niezależne sceny: Main Stage, " +
                    "Noise Stage i Progresja Cafe. Klub ma także wspaniale rozwinięte zaplecze barowe - " +
                    "szeroki wybór piw rzemieślniczych i innych alkoholi. Na scenie Progresji występowali między innymi: " +
                    "Behemoth, White Lies, Riverside, Imany, Mastodon, Billy Talent, Marka „Prezesa” Laskowskiego, Machine Gun Kelly, Coma, " +
                    "Chylińska i wielu innych znakomitych artystów.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "01-258",
                            CityID = getCityId("Warszawa"),
                            Street = "Fort Wola",
                            StreetNo = "22"
                        },
                    Capacity = 2000
                },
                new Venue ()
                {
                    Name = "Arena Gliwice",
                    Description = "Arena Gliwice to obiekt halowy o przeznaczeniu widowiskowo-sportowym. " +
                    "To także jeden z najnowocześniejszych i największych obiektów tego rodzaju w Polsce. Na Śląsku nie ma sobie równych.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "44-100",
                            CityID = getCityId("Gliwice"),
                            Street = "Akademicka",
                            StreetNo = "50"
                        },
                    Capacity = 13300
                },
                new Venue ()
                {
                    Name = "Klub Wytwórnia",
                    Description = "Łódzki klub muzyczny działający od 2007 roku, którego właścicielem jest Grupa Toya. " +
                    "Poza koncertami, w klubie organizowane są również spektakle filmowe oraz teatralne, wystawy sztuki, " +
                    "spotkania z artystami, imprezy zamknięte, bankiety czy różnego rodzaju festiwale",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "90-554",
                            CityID = getCityId("Łódź"),
                            Street = "Łąkowa",
                            StreetNo = "29"
                        },
                    Capacity = 1600
                },
                new Venue ()
                {
                    Name = "COS Torwar",
                    Description = "Dzięki dogodnej lokalizacji w centrum miasta Torwar to jedno z najlepszych miejsc do organizacji wielu imprez muzycznych. " +
                    "Występowali tutaj najwięksi polscy i światowi artyści, m.in. " +
                    "Jean Michel Jarre, Lenny Kravitz, The Prodigy, Hurts czy Placebo. " +
                    "Warto także wspomnieć o imprezach cyklicznych i trasach koncertowych takich jak Disney On Ice, " +
                    "koncerty Chóru Aleksandrowa, czy występy Moscow City Ballet.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "00-449",
                            CityID = getCityId("Warszawa"),
                            Street = "Łazienkowska",
                            StreetNo = "6A"
                        },
                    Capacity = 4800
                },
                new Venue ()
                {
                    Name = "Palladium",
                    Description = "Klub Palladium to jeden z najpopularniejszych obiektów na kulturalno-rozrywkowej mapie stolicy Polski - Warszawy. " +
                    "Od początku swojego istnienia mieści się w samym centrum miasta, przy ul. Złotej 9. " +
                    "Obecnie w Klubie Palladium odbywają się rozmaite wydarzenia kulturalno-rozrywkowe – koncerty i spektakle teatralne.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "00-019",
                            CityID = getCityId("Warszawa"),
                            Street = "Złota",
                            StreetNo = "9"
                        },
                    Capacity = 620
                },
                new Venue ()
                {
                    Name = "Scena",
                    Description = "Scena Sopot organizuje wydarzenia rozrywkowe i kulturalne. " +
                    "Obiekt ulokowany w zachwycającej scenerii sopockiej plaży, w pobliżu molo, " +
                    "jest znakomitym miejscem do zabawy przy dźwiękach muzyki na żywo. " +
                    "Odbywają się w nim koncerty, kabarety, ale też bankiety, szkolenia i imprezy firmowe.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "81-729",
                            CityID = getCityId("Sopot"),
                            Street = "Al. Franciszka Mamuszki",
                            StreetNo = "2"
                        },
                    Capacity = 2000
                },
                new Venue ()
                {
                    Name = "Stary Maneż",
                    Description = "Stary Maneż to gdański klub muzyczny a zarazem dom kultury, uruchomiony w październiku 2015 roku. " +
                    "Obiekt, zajmujący m.in. tereny XIX-wiecznej ujeżdżalni kawalerii zwanej Czarnymi Huzarami, " +
                    "mieści się u zbiegu ulic Chrzanowskiego i Słowackiego. Stary Maneż Gdańsk jest miejscem niezwykle klimatycznym.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "80-257",
                            CityID = getCityId("Gdańsk"),
                            Street = "Juliusza Słowackiego",
                            StreetNo = "23"
                        },
                    Capacity = 1490
                },
                new Venue ()
                {
                    Name = "Arena Toruń",
                    Description = "Arena Toruń to hala sportowa i widowiskowa mieszcząca się przy ulicy Generała Józefa Bema 73-89 w Toruniu. " +
                    "Hala została oficjalnie otwarta 10 sierpnia 2014 roku. " +
                    "Odbywają się tutaj przede wszystkim wydarzenia o charakterze sportowym, " +
                    "często jednak organizowane są tu również wydarzenia kulturalno-rozrywkowe, takie jak koncerty i spektakle.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "87-100",
                            CityID = getCityId("Toruń"),
                            Street = "Generała Józefa Bema",
                            StreetNo = "73/89"
                        },
                    Capacity = 5780
                },
                new Venue ()
                {
                    Name = "Ergo Arena",
                    Description = "ERGO ARENA to hala widowiskowo – sportowa położona na granicy dwóch miast: Gdańska i Sopotu (plac Dwóch Miast 1). " +
                    "Obiekt, oddany do użytku w 2010 roku, może pomieścić ponad 11 000 widzów (miejsca siedzące). " +
                    "Duża powierzchnia ERGO ARENY pozwala na organizację imprez masowych, takich jak wydarzenia sportowe, " +
                    "koncerty, widowiska muzyczne i kulturalne, targi oraz konferencje.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "80-344",
                            CityID = getCityId("Gdańsk"),
                            Street = "plac Dwóch Miast",
                            StreetNo = "1"
                        },
                    Capacity = 15000
                },
                new Venue ()
                {
                    Name = "Stadion Śląski",
                    Description = "Stadion Śląski mieści się przy ulicy Katowickiej 10 w Chorzowie. " +
                    "Stadion Śląski został ponownie otwarty 1 października 2017 roku. " +
                    "Modernizacja zakończyła się oddaniem do użytku obiektu spełniającego najwyższe wymogi stawiane zarówno stadionom piłkarskim, jak i stadionom lekkoatletycznym.",
                    Address= new Address()
                        {
                            Country="Polska",
                            PostalCode = "41-500",
                            CityID = getCityId("Chorzów"),
                            Street = "Katowicka",
                            StreetNo = "10"
                        },
                    Capacity = 15000
                }
                };

            return venues;
        }

        private IEnumerable<Event> getEvents()
        {
            var events = new List<Event>()
            {
                new Event()
                {
                    Name="Electric Callboy",
                    Description="_electric1",
                    VenueId = getVenueId("Progresja"),
                    StartDateTime=new DateTime(2023,04,10,20,00,00),
                    EndDateTime=new DateTime(2023,04,10,23,30,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Hard/Heavy"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Electric Callboy") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=1700,
                                Price = 120m,
                                IsStanding = true
                            },
                            new Section()
                            {
                                Name="VIP",
                                Capacity=300,
                                Price=249m,
                                IsStanding = true
                            }
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "627998a6-7bc5-4749-b2d9-f9f01f659d3c.jpg", ImageType = ImageType.Carousel },
                            new Image() { FileName = "d775b5ff-7f2e-4a0c-8ced-0e33cbb1c81f.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "0c54fee5-8e6f-404c-b998-6764fe27e55d.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 10
                },
                new Event()
                {
                    Name="Electric Callboy",
                    Description="_electric1",
                    VenueId = getVenueId("Scena"),
                    StartDateTime=new DateTime(2023,04,12,19,30,00),
                    EndDateTime=new DateTime(2023,04,12,23,00,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Hard/Heavy"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Electric Callboy") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=1800,
                                Price = 120m,
                                IsStanding = true
                            },
                            new Section()
                            {
                                Name="VIP",
                                Capacity=200,
                                Price=249m,
                                IsStanding = true
                            }
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "d775b5ff-7f2e-4a0c-8ced-0e33cbb1c81f.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "7f4a4c4b-8b5b-421a-be6f-b08bbd58d6b9.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 10
                },
                new Event()
                {
                    Name="Electric Callboy",
                    Description="_electric1",
                    VenueId = getVenueId("Narodowe Forum Muzyki we Wrocławiu"),
                    StartDateTime=new DateTime(2023,04,14,19,30,00),
                    EndDateTime=new DateTime(2023,04,14,23,00,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Hard/Heavy"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Electric Callboy") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="Main hall",
                                Capacity=960,
                                Price = 120m,
                                Rows = new List<Row>()
                                {
                                    new Row() { Name="A", Seats = getSeats(20) },
                                    new Row() { Name="B", Seats = getSeats(20) },
                                    new Row() { Name="C", Seats = getSeats(20) },
                                    new Row() { Name="D", Seats = getSeats(20) },
                                    new Row() { Name="E", Seats = getSeats(20) },
                                    new Row() { Name="F", Seats = getSeats(20) },
                                    new Row() { Name="G", Seats = getSeats(20) },
                                    new Row() { Name="H", Seats = getSeats(20) },
                                    new Row() { Name="I", Seats = getSeats(20) },
                                    new Row() { Name="J", Seats = getSeats(20) },
                                    new Row() { Name="K", Seats = getSeats(20) },
                                    new Row() { Name="L", Seats = getSeats(20) },
                                    new Row() { Name="M", Seats = getSeats(20) }
                                }
                            },
                            new Section()
                            {
                                Name="VIP",
                                Capacity=180,
                                Price=249m,
                                Rows = new List<Row>()
                                {
                                    new Row() { Name="V1", Seats = getSeats(20) },
                                    new Row() { Name="V2", Seats = getSeats(20) },
                                    new Row() { Name="V3", Seats = getSeats(20) }
                                }
                            }
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "d775b5ff-7f2e-4a0c-8ced-0e33cbb1c81f.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "344c0011-30f4-4c34-91d9-03a95f6a5d00.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 10
                },
                new Event()
                {
                    Name="Sting",
                    Description="_sting1",
                    VenueId = getVenueId("TAURON Arena Kraków"),
                    StartDateTime=new DateTime(2023,07,20,18,00,00),
                    EndDateTime=new DateTime(2023,07,20,23,00,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Rock/Pop"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Sting") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=5000,
                                Price = 249m,
                                IsStanding = true
                            },
                            new Section()
                            {
                                Name="Golden circle",
                                Capacity=1000,
                                Price=349m,
                                IsStanding = true
                            },
                            new Section()
                            {
                                Name="Golden circle Early Entry",
                                Capacity=500,
                                Price=499m,
                                IsStanding = true
                            },
                            getSeatingSection("A1",299m, 20, 14),
                            getSeatingSection("A2",299m, 20, 14),
                            getSeatingSection("A3",249m, 20, 14),
                            getSeatingSection("A4",249m, 20, 14),
                            getSeatingSection("A5",249m, 20, 14),
                            getSeatingSection("A6",249m, 20, 14),
                            getSeatingSection("A7",249m, 20, 14),
                            getSeatingSection("A8",249m, 20, 14),
                            getSeatingSection("A9",299m, 20, 14),
                            getSeatingSection("A10",299m, 20, 14),
                            getSeatingSection("A11",249m, 20, 14),
                            getSeatingSection("A12",249m, 20, 14),
                            getSeatingSection("A13",249m, 20, 14)
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "87378d6d-2604-4952-a640-c94e656ca998.jpg", ImageType = ImageType.Carousel },
                            new Image() { FileName = "3379366a-5ced-40bf-9a23-50747f7b0916.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "ee2f6c57-697a-4260-b937-686c40b6c69b.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 6
                },
                new Event()
                {
                    Name="Sting",
                    Description="_sting1",
                    VenueId = getVenueId("Atlas Arena"),
                    StartDateTime=new DateTime(2023,07,22,18,00,00),
                    EndDateTime=new DateTime(2023,07,22,23,00,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Rock/Pop"),
                     EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Sting") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=4500,
                                Price = 279m,
                                IsStanding = true
                            },
                            new Section()
                            {
                                Name="Golden circle",
                                Capacity=1500,
                                Price=369m,
                                IsStanding = true
                            },
                            new Section()
                            {
                                Name="Golden circle Early Entry",
                                Capacity=500,
                                Price=519m,
                                IsStanding = true
                            },
                            getSeatingSection("A",149m, 20, 14),
                            getSeatingSection("B",149m, 20, 14),
                            getSeatingSection("C",149m, 20, 14),
                            getSeatingSection("D",149m, 20, 14),
                            getSeatingSection("E",199m, 20, 14),
                            getSeatingSection("F",199m, 20, 14),
                            getSeatingSection("O",199m, 20, 14),
                            getSeatingSection("P",199m, 20, 14),
                            getSeatingSection("R",149m, 20, 14),
                            getSeatingSection("S",149m, 20, 14),
                            getSeatingSection("T",149m, 20, 14),
                            getSeatingSection("U",149m, 20, 14),
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "3379366a-5ced-40bf-9a23-50747f7b0916.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "d4f804c7-e858-49cd-91ec-73bcf14f41d4.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 6
                },
                new Event()
                {
                    Name="Sanah",
                    Description="_sanah1",
                    VenueId = getVenueId("Atlas Arena"),
                    StartDateTime=new DateTime(2023,08,17,18,00,00),
                    EndDateTime=new DateTime(2023,08,17,23,00,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Rock/Pop"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Sanah") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=9000,
                                Price = 199m,
                                IsStanding = true
                            },
                            new Section()
                            {
                                Name="Golden circle Early Entry",
                                Capacity=2000,
                                Price=399m,
                                IsStanding = true
                            },
                            getSeatingSection("A",149m, 20, 14),
                            getSeatingSection("B",149m, 20, 14),
                            getSeatingSection("C",149m, 20, 14),
                            getSeatingSection("D",149m, 20, 14),
                            getSeatingSection("E",199m, 20, 14),
                            getSeatingSection("F",199m, 20, 14),
                            getSeatingSection("O",199m, 20, 14),
                            getSeatingSection("P",199m, 20, 14),
                            getSeatingSection("R",149m, 20, 14),
                            getSeatingSection("S",149m, 20, 14),
                            getSeatingSection("T",149m, 20, 14),
                            getSeatingSection("U",149m, 20, 14),
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "21c9749c-e027-4e37-9553-8a5bc8505835.jpg", ImageType = ImageType.Carousel },
                            new Image() { FileName = "5d58cc1a-96ff-4211-9c1f-37dfc5eb67b0.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "d4f804c7-e858-49cd-91ec-73bcf14f41d4.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 6
                },
                new Event()
                {
                    Name="Sanah",
                    Description="_sanah1",
                    VenueId = getVenueId("TAURON Arena Kraków"),
                    StartDateTime=new DateTime(2023,08,22,18,00,00),
                    EndDateTime=new DateTime(2023,08,22,23,00,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Rock/Pop"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Sanah") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=9000,
                                Price = 189m,
                                IsStanding = true
                            },
                            new Section()
                            {
                                Name="Golden circle Early Entry",
                                Capacity=2000,
                                Price=389m,
                                IsStanding = true
                            },
                            getSeatingSection("A1",199m, 20, 14),
                            getSeatingSection("A2",199m, 20, 14),
                            getSeatingSection("A3",149m, 20, 14),
                            getSeatingSection("A4",149m, 20, 14),
                            getSeatingSection("A5",149m, 20, 14),
                            getSeatingSection("A6",149m, 20, 14),
                            getSeatingSection("A7",149m, 20, 14),
                            getSeatingSection("A8",149m, 20, 14),
                            getSeatingSection("A9",199m, 20, 14),
                            getSeatingSection("A10",199m, 20, 14),
                            getSeatingSection("A11",149m, 20, 14),
                            getSeatingSection("A12",149m, 20, 14),
                            getSeatingSection("A13",149m, 20, 14)
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "5d58cc1a-96ff-4211-9c1f-37dfc5eb67b0.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "ee2f6c57-697a-4260-b937-686c40b6c69b.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 6
                },
                new Event()
                {
                    Name="Mistrzostwa Świata Super Enduro - Dzień I",
                    Description="_enduro1",
                    VenueId = getVenueId("Arena Gliwice"),
                    StartDateTime=new DateTime(2023,03,18,17,30,00),
                    EndDateTime=new DateTime(2023,03,18,22,30,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Sport", "Motor sports"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Mistrzostwa Świata Super Enduro") }
                        },
                    Sections = new List<Section>()
                        {
                            getSeatingSection("1-01",249m, 20, 14),
                            getSeatingSection("1-02",249m, 20, 14),
                            getSeatingSection("1-03",249m, 20, 14),
                            getSeatingSection("1-04",249m, 20, 14),
                            getSeatingSection("1-05",299m, 20, 14),
                            getSeatingSection("1-06",299m, 20, 14),
                            getSeatingSection("1-07",299m, 20, 14),
                            getSeatingSection("1-08",299m, 20, 14),
                            getSeatingSection("1-09",249m, 20, 14),
                            getSeatingSection("1-10",249m, 20, 14),
                            getSeatingSection("1-11",249m, 20, 14),
                            getSeatingSection("1-12",249m, 20, 14),
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "61137713-e7bf-400b-b590-851490b47807.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "a3fac08d-1541-4427-aacd-8b8e14295632.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 10
                },
                new Event()
                {
                    Name="Mistrzostwa Świata Super Enduro - Dzień II",
                    Description="_enduro1",
                    VenueId = getVenueId("Arena Gliwice"),
                    StartDateTime=new DateTime(2023,03,19,17,30,00),
                    EndDateTime=new DateTime(2023,03,19,22,30,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Sport", "Motor sports"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Mistrzostwa Świata Super Enduro") }
                        },
                    Sections = new List<Section>()
                        {
                            getSeatingSection("1-01",49m, 20, 14),
                            getSeatingSection("1-02",49m, 20, 14),
                            getSeatingSection("1-03",49m, 20, 14),
                            getSeatingSection("1-04",49m, 20, 14),
                            getSeatingSection("1-05",99m, 20, 14),
                            getSeatingSection("1-06",99m, 20, 14),
                            getSeatingSection("1-07",99m, 20, 14),
                            getSeatingSection("1-08",99m, 20, 14),
                            getSeatingSection("1-09",49m, 20, 14),
                            getSeatingSection("1-10",49m, 20, 14),
                            getSeatingSection("1-11",49m, 20, 14),
                            getSeatingSection("1-12",49m, 20, 14),
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "61137713-e7bf-400b-b590-851490b47807.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "a3fac08d-1541-4427-aacd-8b8e14295632.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 10
                },
                new Event()
                {
                    Name="Hot Wheels Monster Trucks Live Glow Party",
                    Description="_hotWheels1",
                    VenueId = getVenueId("TAURON Arena Kraków"),
                    StartDateTime=new DateTime(2023,04,14,20,00,00),
                    EndDateTime=new DateTime(2023,04,14,23,30,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Sport", "Motor sports"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Hot Wheels Monster Trucks Live Glow Party") }
                        },
                    Sections = new List<Section>()
                        {
                            getSeatingSection("A1",199m, 20, 14),
                            getSeatingSection("A2",199m, 20, 14),
                            getSeatingSection("A3",149m, 20, 14),
                            getSeatingSection("A4",149m, 20, 14),
                            getSeatingSection("A5",149m, 20, 14),
                            getSeatingSection("A6",149m, 20, 14),
                            getSeatingSection("A7",149m, 20, 14),
                            getSeatingSection("A8",149m, 20, 14),
                            getSeatingSection("A9",199m, 20, 14),
                            getSeatingSection("A10",199m, 20, 14),
                            getSeatingSection("A11",149m, 20, 14),
                            getSeatingSection("A12",149m, 20, 14),
                            getSeatingSection("A13",149m, 20, 14)
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "b1ae1e1c-2d3d-4ce1-aa6b-efccbfa384f9.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "ee2f6c57-697a-4260-b937-686c40b6c69b.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 10
                },
                new Event()
                {
                    Name="POLSKA - ALBANIA, EL. MISTRZOSTW EUROPY 2024",
                    Description="_polandAlbania1",
                    VenueId = getVenueId("Stadion Narodowy (PGE Narodowy)"),
                    StartDateTime=new DateTime(2023,03,27,20,45,00),
                    EndDateTime=new DateTime(2023,03,27,22,45,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Sport", "Football"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Reprezentacja Polski w piłce nożnej") },
                            new EventPerformer() { PerformerId = getPerformerId("Reprezentacja Albanii w piłce nożnej") },
                        },
                    Sections = new List<Section>()
                        {
                            getSeatingSection("G1",199m, 20, 14),
                            getSeatingSection("G2",199m, 20, 14),
                            getSeatingSection("G3",149m, 20, 14),
                            getSeatingSection("G4",149m, 20, 14),
                            getSeatingSection("G5",149m, 20, 14),
                            getSeatingSection("G6",149m, 20, 14),
                            getSeatingSection("G7",149m, 20, 14),
                            getSeatingSection("G8",149m, 20, 14),
                            getSeatingSection("G9",199m, 20, 14),
                            getSeatingSection("G10",199m, 20, 14),
                            getSeatingSection("G11",149m, 20, 14),
                            getSeatingSection("G12",149m, 20, 14),
                            getSeatingSection("G13",149m, 20, 14),
                            getSeatingSection("G14",199m, 20, 14),
                            getSeatingSection("G15",199m, 20, 14),
                            getSeatingSection("G16",149m, 20, 14),
                            getSeatingSection("G17",149m, 20, 14),
                            getSeatingSection("G18",149m, 20, 14),
                            getSeatingSection("G19",149m, 20, 14),
                            getSeatingSection("G20",149m, 20, 14),
                            getSeatingSection("G21",149m, 20, 14),
                            getSeatingSection("G22",199m, 20, 14),
                            getSeatingSection("G23",199m, 20, 14),
                            getSeatingSection("G24",149m, 20, 14),
                            getSeatingSection("G25",149m, 20, 14),
                            getSeatingSection("G26",149m, 20, 14)
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "404843d8-5b06-437a-9a9f-5d3dc5d5142f.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "378bf5b7-701f-488b-badf-34a9268f80a8.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 10
                },
                new Event()
                {
                    Name="POLSKA - WYSPY OWCZE, EL. MISTRZOSTW EUROPY 2024",
                    Description="_polandFaroeIslands1",
                    VenueId = getVenueId("Stadion Narodowy (PGE Narodowy)"),
                    StartDateTime=new DateTime(2023,09,07,20,45,00),
                    EndDateTime=new DateTime(2023,09,07,22,45,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Sport", "Football"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Reprezentacja Polski w piłce nożnej") },
                            new EventPerformer() { PerformerId = getPerformerId("Reprezentacja Wysp Owczych w piłce nożnej") },
                        },
                    Sections = new List<Section>()
                        {
                            getSeatingSection("G1",199m, 20, 14),
                            getSeatingSection("G2",199m, 20, 14),
                            getSeatingSection("G3",149m, 20, 14),
                            getSeatingSection("G4",149m, 20, 14),
                            getSeatingSection("G5",149m, 20, 14),
                            getSeatingSection("G6",149m, 20, 14),
                            getSeatingSection("G7",149m, 20, 14),
                            getSeatingSection("G8",149m, 20, 14),
                            getSeatingSection("G9",199m, 20, 14),
                            getSeatingSection("G10",199m, 20, 14),
                            getSeatingSection("G11",149m, 20, 14),
                            getSeatingSection("G12",149m, 20, 14),
                            getSeatingSection("G13",149m, 20, 14),
                            getSeatingSection("G14",199m, 20, 14),
                            getSeatingSection("G15",199m, 20, 14),
                            getSeatingSection("G16",149m, 20, 14),
                            getSeatingSection("G17",149m, 20, 14),
                            getSeatingSection("G18",149m, 20, 14),
                            getSeatingSection("G19",149m, 20, 14),
                            getSeatingSection("G20",149m, 20, 14),
                            getSeatingSection("G21",149m, 20, 14),
                            getSeatingSection("G22",199m, 20, 14),
                            getSeatingSection("G23",199m, 20, 14),
                            getSeatingSection("G24",149m, 20, 14),
                            getSeatingSection("G25",149m, 20, 14),
                            getSeatingSection("G26",149m, 20, 14)
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "4974572d-7262-4449-a1c4-350152c644e7.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "378bf5b7-701f-488b-badf-34a9268f80a8.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 10
                },
                new Event()
                {
                    Name="Alpha Wolf + King 810, Ten56, Xile",
                    Description="_alphaWolf1",
                    VenueId = getVenueId("Klub Wytwórnia"),
                    StartDateTime=new DateTime(2023,09,24,20,00,00),
                    EndDateTime=new DateTime(2023,09,24,23,00,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Hard/Heavy"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Alpha Wolf") },
                            new EventPerformer() { PerformerId = getPerformerId("King 810") },
                            new EventPerformer() { PerformerId = getPerformerId("Ten56") },
                            new EventPerformer() { PerformerId = getPerformerId("Xile") },
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=1600,
                                Price = 99m,
                                IsStanding = true
                            }
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "54216bd5-066a-40e5-89c4-582e03036c9e.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "147a81d8-8264-4fa0-980b-a78f21699090.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 6
                },
                new Event()
                {
                    Name="Sylwester z Chopinem",
                    Description="_chopin1",
                    VenueId = getVenueId("Gdański Teatr Szekspirowski"),
                    StartDateTime=new DateTime(2023,12,31,20,00,00),
                    EndDateTime=new DateTime(2024,01,01,05,00,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Classical music"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Prof. Maciej Poliszewski") }
                        },
                    Sections = new List<Section>()
                        {
                            getSeatingSection("Aula",499m, 20, 15)
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "1d936cec-9cf7-4886-afd2-298b3e8a6704.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "6cdc55f4-793e-45a4-adaa-636c5026e394.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 6
                },
                new Event()
                {
                    Name="Klub mężusiów",
                    Description="_husbandClub1",
                    VenueId = getVenueId("Gdański Teatr Szekspirowski"),
                    StartDateTime=new DateTime(2023,10,11,20,00,00),
                    EndDateTime=new DateTime(2024,10,11,22,30,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Culture", "Theatre"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Klub mężusiów") }
                        },
                    Sections = new List<Section>()
                        {
                            getSeatingSection("Aula",99m, 20, 15)
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "cb2eab55-503e-484c-af40-78a6c6fcc4a4.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "6cdc55f4-793e-45a4-adaa-636c5026e394.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 10
                },
                new Event()
                {
                    Name="Metallica symfonicznie",
                    Description="_metallica1",
                    VenueId = getVenueId("Filharmonia im. Mieczysława Karłowicza w Szczecinie"),
                    StartDateTime=new DateTime(2023,06,16,20,00,00),
                    EndDateTime=new DateTime(2023,06,16,23,00,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Classical music"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Orion") }
                        },
                    Sections = new List<Section>()
                        {
                            getSeatingSection("Sala główna", 299m, 30, 10)
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "1e4147dc-13ce-4c12-b1a1-3cda61f3f67f.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "481c29a2-14bc-428d-a7d9-b1c15a1eb45a.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 6
                },
                new Event()
                {
                    Name="Metallica symfonicznie",
                    Description="_metallica1",
                    VenueId = getVenueId("Filharmonia Łódzka"),
                    StartDateTime=new DateTime(2023,06,22,20,00,00),
                    EndDateTime=new DateTime(2023,06,22,23,00,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Classical music"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Orion") }
                        },
                    Sections = new List<Section>()
                        {
                            getSeatingSection("Sala główna", 299m, 20, 15)
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "1e4147dc-13ce-4c12-b1a1-3cda61f3f67f.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "e9bbc244-d9d6-4265-af7b-34f3e001d8fc.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 6
                },
                new Event()
                {
                    Name="Zenon Martyniuk",
                    Description="_martyniuk1",
                    VenueId = getVenueId("Arena Gliwice"),
                    StartDateTime=new DateTime(2023,07,07,17,30,00),
                    EndDateTime=new DateTime(2023,07,07,22,30,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Disco/Dance"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Zenon Martyniuk") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=4000,
                                Price = 149m,
                                IsStanding = true,
                            },
                            new Section()
                            {
                                Name="Golden circle",
                                Capacity=2000,
                                Price=249m,
                                IsStanding = true,
                            }
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "9297f61a-cc99-43c7-a9bd-72f9e03af142.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "a3fac08d-1541-4427-aacd-8b8e14295632.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 10
                },
                new Event()
                {
                    Name="Gala Disco vol. 8",
                    Description="_disco1",
                    VenueId = getVenueId("COS Torwar"),
                    StartDateTime=new DateTime(2023,08,17,18,30,00),
                    EndDateTime=new DateTime(2023,08,17,23,30,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Disco/Dance"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Kombi") },
                            new EventPerformer() { PerformerId = getPerformerId("Zenek") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=7000,
                                Price = 89m
                            }
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "d11d8d32-f769-4f76-9273-a3e27228decd.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "cad47e0a-4fd8-45b1-92a8-57d220ad336b.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 10
                },
                new Event()
                {
                    Name="Ethno Jazz Festival: Wirujący Derwisze",
                    Description="_etno1",
                    VenueId = getVenueId("Parlament"),
                    StartDateTime=new DateTime(2023,10,24,18,30,00),
                    EndDateTime=new DateTime(2023,10,24,23,30,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Jazz"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Wirujący Derwisze z bractwa Mawlawi") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=450,
                                Price = 49m
                            }
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "8a387418-34d5-4000-ae5b-7e57c0d8e057.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "65a46300-f4bd-4c6c-8459-169dfb791984.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 10
                },
                new Event()
                {
                    Name="Fisz Emade Tworzywo",
                    Description="_fish1",
                    VenueId = getVenueId("Klub Hybrydy"),
                    StartDateTime=new DateTime(2023,11,06,18,30,00),
                    EndDateTime=new DateTime(2023,11,06,22,30,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Rap/Hip-Hop"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Fisz") },
                            new EventPerformer() { PerformerId = getPerformerId("Emade") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=350,
                                Price = 99m
                            }
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "7a7a9a65-70b3-4ff6-a542-1d65f4914918.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "1e98d483-81f9-4795-9c1f-bb7919cc7f82.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 10
                },
                new Event()
                {
                    Name="The Legend – Powrót Legendy",
                    Description="_legend1",
                    VenueId = getVenueId("Palladium"),
                    StartDateTime=new DateTime(2023,05,05,20,00,00),
                    EndDateTime=new DateTime(2023,05,05,23,30,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Concerts", "Rap/Hip-Hop"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Liroy") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="General Admission",
                                Capacity=250,
                                Price = 109m
                            }
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "301ccedf-e5bb-4243-8a86-d209170f868d.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "969cc8d9-4472-4894-ada7-2abb3767f000.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 10
                },
                new Event()
                {
                    Name="Przekręt (nie)doskonały",
                    Description="_przekret1",
                    VenueId = getVenueId("Gdański Teatr Szekspirowski"),
                    StartDateTime=new DateTime(2023,06,06,20,00,00),
                    EndDateTime=new DateTime(2023,06,06,23,30,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Culture", "Theatre"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Donald Churchill") },
                            new EventPerformer() { PerformerId = getPerformerId("Peter Yeldhman") },
                        },
                    Sections = new List<Section>()
                        {
                            getSeatingSection("Aula",399m, 20, 15)
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "9330b0b2-509f-4598-b3ce-826ff5442126.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "6cdc55f4-793e-45a4-adaa-636c5026e394.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 10
                },
                new Event()
                {
                    Name="Przekręt (nie)doskonały",
                    Description="_przekret1",
                    VenueId = getVenueId("Gdański Teatr Szekspirowski"),
                    StartDateTime=new DateTime(2023,06,08,20,00,00),
                    EndDateTime=new DateTime(2023,06,08,23,30,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Culture", "Theatre"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Donald Churchill") },
                            new EventPerformer() { PerformerId = getPerformerId("Peter Yeldhman") }
                        },
                    Sections = new List<Section>()
                        {
                            getSeatingSection("Aula",399m, 20, 15)
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "9330b0b2-509f-4598-b3ce-826ff5442126.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "6cdc55f4-793e-45a4-adaa-636c5026e394.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 10
                },
                new Event()
                {
                    Name="Narodowy Balet Gruzji - Sukhishvili",
                    Description="_sukhishvili1",
                    VenueId = getVenueId("Narodowe Forum Muzyki we Wrocławiu"),
                    StartDateTime=new DateTime(2023,07,25,20,00,00),
                    EndDateTime=new DateTime(2023,07,25,23,30,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Culture", "Ballet/Dance"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Sukhishvili") }
                        },
                    Sections = new List<Section>()
                        {
                            new Section()
                            {
                                Name="Main hall",
                                Capacity=960,
                                Price = 79m,
                                Rows = new List<Row>()
                                {
                                    new Row() { Name="A", Seats = getSeats(20) },
                                    new Row() { Name="B", Seats = getSeats(20) },
                                    new Row() { Name="C", Seats = getSeats(20) },
                                    new Row() { Name="D", Seats = getSeats(20) },
                                    new Row() { Name="E", Seats = getSeats(20) },
                                    new Row() { Name="F", Seats = getSeats(20) },
                                    new Row() { Name="G", Seats = getSeats(20) },
                                    new Row() { Name="H", Seats = getSeats(20) },
                                    new Row() { Name="I", Seats = getSeats(20) },
                                    new Row() { Name="J", Seats = getSeats(20) },
                                    new Row() { Name="K", Seats = getSeats(20) },
                                    new Row() { Name="L", Seats = getSeats(20) },
                                    new Row() { Name="M", Seats = getSeats(20) }
                                }
                            },
                            new Section()
                            {
                                Name="VIP",
                                Capacity=180,
                                Price=249m,
                                Rows = new List<Row>()
                                {
                                    new Row() { Name="V1", Seats = getSeats(20) },
                                    new Row() { Name="V2", Seats = getSeats(20) },
                                    new Row() { Name="V3", Seats = getSeats(20) }
                                }
                            }
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "9338202c-e18a-42c3-8341-59e193233568.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "344c0011-30f4-4c34-91d9-03a95f6a5d00.jpg", ImageType = ImageType.SeatingPlan }

                        },
                        LimitPerUser = 10
                },
                new Event()
                {
                    Name="Musical METRO",
                    Description="_metro1",
                    VenueId = getVenueId("Filharmonia im. Mieczysława Karłowicza w Szczecinie"),
                    StartDateTime=new DateTime(2023,10,10,20,00,00),
                    EndDateTime=new DateTime(2023,10,10,22,30,00),
                    CreateDateTime= new RandomDate().Date(),
                    EventSubCategoryId= getEventSubcategoryId("Culture", "Musical"),
                    EventPerformers = new List<EventPerformer>()
                        {
                            new EventPerformer() { PerformerId = getPerformerId("Metro") }
                        },
                    Sections = new List<Section>()
                        {
                            getSeatingSection("Patio", 99m, 22, 16)
                        },
                        Images = new List<Image>()
                        {
                            new Image() { FileName = "cf3ce019-c835-4cbb-8fe9-5124b98dff0d.jpg", ImageType = ImageType.Card },
                            new Image() { FileName = "481c29a2-14bc-428d-a7d9-b1c15a1eb45a.jpg", ImageType = ImageType.SeatingPlan }
                        },
                        LimitPerUser = 10
                }
            };
            return events;
        }

        private int getCityId(string cityName)
        {
            var city = _context
                .Cities
                .AsNoTracking()
                .FirstOrDefault(v => v.Name == cityName);

            if (city is null)
                throw new Exception($"Venue '{city}' not found");

            return city.Id;
        }

        private int getVenueId(string venueName)
        {
            var venue = _context
                .Venues
                .AsNoTracking()
                .Select(v => new { v.Id, v.Name })
                .FirstOrDefault(v => v.Name == venueName);

            if (venue is null)
                throw new Exception($"Venue '{venueName}' not found");

            return venue.Id;
        }

        private int getEventSubcategoryId(string categoryName, string subCategoryName)
        {
            var subCategory = _context
                .EventSubCategories
                .Include(e => e.Category)
                .AsNoTracking()
                .FirstOrDefault(v => v.Category.Title == categoryName && v.Title == subCategoryName);

            if (subCategory is null)
                throw new Exception($"Subcategory '{subCategoryName}' in category '{categoryName}' not found");

            return subCategory.Id;
        }

        private int getPerformerId(string performerName)
        {
            var performer = _context
                .Performers
                .AsNoTracking()
                .Select(v => new { v.Id, v.Name })
                .FirstOrDefault(v => v.Name == performerName);

            if (performer is null)
                throw new Exception($"Performer '{performerName}' not found");

            return performer.Id;
        }

        private List<Row> getNumericRowsWithSeats(int noOfRows, int noOfSeatsInRow, int sectionId)
        {
            var rows = new List<Row>();
            for (int i = 1; i <= noOfRows; i++)
            {
                var seats = new List<Seat>();
                for (int j = 1; j < noOfSeatsInRow; j++)
                {
                    var seat = new Seat() { Number = j };
                    seats.Add(seat);
                }

                var newRow = new Row()
                {
                    SectionId = sectionId,
                    Name = i.ToString(),
                    Seats = seats
                };
            }
            return rows;
        }

        private List<Seat> getSeats(int noOfSeats)
        {

            var seats = new List<Seat>();
            for (int j = 1; j < noOfSeats; j++)
            {
                var seat = new Seat() { Number = j };
                seats.Add(seat);
            }

            return seats;
        }

        private Section getSeatingSection(string name, decimal price, int noOfRows, int noOfSeatsInRow)
        {
            var rows = new List<Row>();
            int sumOfPlaces = 0;

            for (int i = 0; i < noOfRows; i++)
            {
                var newRow = new Row() { Name = (i + 1).ToString(), Seats = getSeats(noOfSeatsInRow) };
                sumOfPlaces += noOfSeatsInRow;
                rows.Add(newRow);
            }

            return new Section()
            {
                Name = name,
                Capacity = sumOfPlaces,
                Price = price,
                Rows = rows
            };
        }
    }
}
