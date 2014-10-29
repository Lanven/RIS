--В основном все создается на сервере А для большей наглядности.


--/////////////CATEGORIES/////////////////////////////
INSERT INTO sb.categories (title) VALUES ('ПМИ');

SELECT * FROM sb.categories WHERE title LIKE 'ПМИ';
SELECT * FROM sb.categories WHERE id = ;

UPDATE sb.categories SET title = 'ПМИ01' WHERE id = ;

func_distribution_goods_on_insert(CATEGORY_ID!!!,46,'ПМИ',287589,'Aaaaaaa');

DELETE FROM sb.categories WHERE id = ;
SELECT * FROM sb.goods_main WHERE category_id = ;

--///////////////////////////////////////////////////

--////////////CLIENTS///////////////////////////////

--проверка на уникальный ключ по паспортным данным
select func_distribution_clients_on_insert ('Назарова','Мария','Леонидовна','1944-4-12','+7442706145','Mariya.L.Nazarova@goldmail.ru','г. Новосибирск, ул. Крупской 3 Пер., д. 52, кв. 50','2887','679909','1964-6-23','670-323');
--добавим новую запись
select func_distribution_clients_on_insert ('Назарова','Мария','Леонидовна','1944-4-12','+7442706145','Mariya.L.Nazarova@goldmail.ru','г. Новосибирск, ул. Крупской 3 Пер., д. 52, кв. 50','0000','679909','1964-6-23','670-323');

select func_client_on_update (50006,'Смирных','Мария','Леонидовна','1944-4-12','+7442706145','Mariya.L.Nazarova@goldmail.ru','г. Новосибирск, ул. Крупской 3 Пер., д. 52, кв. 50','0001','679909','1964-6-23','670-323');

select func_distribution_orders_on_insert (1050,50007,'2014-8-2',500,2,2,'hgvhjg');

SELECT * FROM sb.orders_main WHERE client_id = 50007;

select func_delete_client(50007);

--///////////////////////////////////////////////////////////////////

--////////////////COMPANIES/////////////////////////////////////////

--создаем компанию на А сервере
INSERT INTO sb.companies (name, country_id, head_full_name, phone, address, bank_details) VALUES ('Аркадия', 1, 'Юдина Ада Андреевна', '+40911093126', 'г. Брисбен, ул. Театральная, д. 64', 'Корр.счёт 3634402429021118675');

SELECT * FROM sa.companies WHERE name LIKE 'Аркадия';

SELECT * FROM sa.companies_monthly WHERE id = COMPANY_ID!!!;

UPDATE sa.companies SET name='Аркадия2' WHERE id = COMPANY_ID!!!;

func_distribution_goods_on_insert(1,COMPANY_ID!!!,'ПМИ',287589,'Aaaaaaa');

SELECT * FROM sa.goods_main WHERE company_id = ;

func_distribution_company_on_delete (COMPANY_ID!!!);

--////////////////////////////////////////////////////////////////////////////

--//////////////////////////GOODS/////////////////////////////////////////////

func_distribution_goods_on_insert(1,97,'ПМИ',287589,'Aaaaaaa');

func_distribution_goods_on_update (ID!!!!, 1, 97, 'ПМИ01', 287589, 'Bbbbbbbb');

SELECT * FROM sa.goods_main WHERE id = ;

func_distribution_orders_on_insert(GOODS_ID!!!,45918,'2014-5-13',50000,1,2);

SELECT * FROM orders_main WHERE goods_id = ;

func_distribution_goods_on_delete (GOODS_ID!!!);

--///////////////////////////////////////////////////////////////////////////

--////////////////////////////ORDERS//////////////////////////////////////

func_distribution_orders_on_insert(10048,45918,'2014-5-13',50000,1,2);

SELECT * FROM sa.goods_main WHERE id = 10048; -- company_id=568;

SELECT * FROM sa.companies_monthly WHERE id = 568; -- смотрим сумму

SELECT * FROM sa.companies WHERE id = 568; -- country_id = 100;

SELECT * FROM sa.countries WHERE id = 100; --смотрим сумму

func_distribution_orders_on_update (ID!!!, 10048,45918,'2014-10-13',100,1,2);

SELECT * FROM sa.companies_monthly WHERE id = 568; -- смотрим сумму

SELECT * FROM sa.countries WHERE id = 100; --смотрим сумму

func_distribution_orders_on_delete (ID!!!); -- так же можно посмотреть две таблицы с суммами..в них записи тоже удалятся.


--////////////////////////////////////////////////////////////////////





