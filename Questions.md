1.Як правильно реалізувати збереження даних (login,id) поточного користувача для використання в прогрмаі?
2.
TradingCompanyWF -> Programm.cs ->
LoginForm lf = Container.Resolve<LoginForm>(new ResolverOverride[] { new ParameterOverride("user", _user) });
Чи правильно перевизначати об'єкт (login,id) користувача при передачі в конструктор з викорисанням UnityContainer? 
(Перевизначення відбувається постійно при виклику будь-якої форми)

3.BusinessLogicTests -> Tests -> AdressManagerTest.cs ->AddAdressTest
-> adressDal.Setup
Якщо в adressDal.Setup(d => d.CreateAdress(...)) передати об'єкт то тест падає.
(Думаю це через то, що в AdressManager створюється новий об'єкт, який передається в CreateAdress(...).Тобто вони різні).
Чи коректно в даному випадку написати тест так?

4.В яких випадках в тестах використовувати MockBehavior.Strict/MockBehavior.Loose ?
