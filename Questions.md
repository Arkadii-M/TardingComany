1.�� ��������� ���������� ���������� ����� (login,id) ��������� ����������� ��� ������������ � �������?
2.
TradingCompanyWF -> Programm.cs ->
LoginForm lf = Container.Resolve<LoginForm>(new ResolverOverride[] { new ParameterOverride("user", _user) });
�� ��������� ������������� ��'��� (login,id) ����������� ��� �������� � ����������� � ������������ UnityContainer? 
(�������������� ���������� ������� ��� ������� ����-��� �����)

3.BusinessLogicTests -> Tests -> AdressManagerTest.cs ->AddAdressTest
-> adressDal.Setup
���� � adressDal.Setup(d => d.CreateAdress(...)) �������� ��'��� �� ���� ����.
(����� �� ����� ��, �� � AdressManager ����������� ����� ��'���, ���� ���������� � CreateAdress(...).����� ���� ���).
�� �������� � ������ ������� �������� ���� ���?

4.� ���� �������� � ������ ��������������� MockBehavior.Strict/MockBehavior.Loose ?
