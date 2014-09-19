
create schema initial;
comment on schema initial is 'Исходная база данных торговой организации';

set search_path to initial;
-------------------------------------------------------------------------------
create table categories
(
  id     serial,
  title  text    not null
);

comment on table categories is 'Категории товаров';
comment on column categories.title is 'Название категории товара';
-------------------------------------------------------------------------------
create table countries
(
  id    serial,
  name  text    not null
);

comment on table countries is 'Список стран';
comment on column countries.name is 'Название страны';
-------------------------------------------------------------------------------
create table payment_methods
(
  id     serial,
  title  text    not null check (title in ('Безналичный', 'Наличный'))
);

comment on table payment_methods is 'Способы оплаты';
comment on column payment_methods.title is 'Название способа оплаты';

insert into payment_methods (title) values ('Безналичный'), ('Наличный');
-------------------------------------------------------------------------------
create table sale_types
(
  id     serial,
  title  text    not null check (title in ('Оптовый', 'Розничный'))
);

comment on table sale_types is 'Виды продаж';
comment on column sale_types.title is 'Название вида продажи';

insert into sale_types (title) values ('Оптовый'), ('Розничный');
-------------------------------------------------------------------------------
create table companies
(
  id              serial,
  name            text     not null,
  country_id      integer  not null,
  head_full_name  text,
  phone           text,
  address         text,
  bank_details    text
);

comment on table companies is 'Компании-производители товаров';
comment on column companies.name           is 'Название компании';
comment on column companies.country_id     is 'Идентификатор страны, из которой компания';
comment on column companies.head_full_name is 'ФИО директора';
comment on column companies.phone          is 'Номер телефона';
comment on column companies.address        is 'Юридический адрес компании';
comment on column companies.bank_details   is 'Банковские реквизиты компании';
-------------------------------------------------------------------------------
create table goods
(
  id           serial,
  category_id  integer  not null,
  company_id   integer  not null,
  model        text     not null,
  price        numeric (12, 2),
  description  text
);

comment on table goods is 'Продаваемые товары';
comment on column goods.category_id is 'Идентификатор категории, к которой относится данный товар';
comment on column goods.company_id  is 'Идентификатор компании-производителя';
comment on column goods.model       is 'Модель товара';
comment on column goods.price       is 'Цена';
comment on column goods.description is 'Описание товара';
-------------------------------------------------------------------------------
create table clients
(
  id                serial,
  surname           text    not null,
  name              text    not null,
  patronymic        text    not null,
  birthdate         date    not null,
  phone             text,
  email             text,
  address           text,
  passport_series   text    not null,
  passport_number   text    not null,
  issue_date        date,
  issue_department  text
);

comment on table clients is 'Покупатели';
comment on column clients.surname          is 'Фамилия';
comment on column clients.name             is 'Имя';
comment on column clients.patronymic       is 'Отчество';
comment on column clients.birthdate        is 'Дата рождения';
comment on column clients.phone            is 'Номер телефона';
comment on column clients.email            is 'Адрес электронной почты';
comment on column clients.address          is 'Адрес доставки';
comment on column clients.passport_series  is 'Серия паспорта';
comment on column clients.passport_number  is 'Номер паспорта';
comment on column clients.issue_date       is 'Дата выдачи паспорта';
comment on column clients.issue_department is 'Код подразделения, выдавшего паспорт';
-------------------------------------------------------------------------------
create table orders
(
  id                serial,
  goods_id          integer not null,
  client_id         integer not null,
  on_sale_date      date    not null,
  sale_amount       numeric (12, 2) not null,
  payment_method_id integer not null,
  sale_type_id      integer not null,
  details           text
);

comment on table orders is 'Осуществлённые продажи товаров';
comment on column orders.goods_id          is 'Идентификатор проданного товара';
comment on column orders.client_id         is 'Идентификатор покупателя';
comment on column orders.on_sale_date      is 'Дата продажи';
comment on column orders.sale_amount       is 'Сумма покупки (может отличаться от цены товара из-за покупки нескольких экземпляров товара сразу, применения скидки или изменения цены товара с течением времени)';
comment on column orders.payment_method_id is 'Идентификатор способа оплаты';
comment on column orders.sale_type_id      is 'Идентификатор вида продажи';
comment on column orders.details           is 'Дополнительная информация о продаже';
-------------------------------------------------------------------------------
