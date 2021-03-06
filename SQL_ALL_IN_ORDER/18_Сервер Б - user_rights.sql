﻿grant select on all tables in schema sb to risbd6_ext;
grant execute on function func_categories_on_delete(p_id integer) to risbd6_ext;
grant execute on function func_categories_on_insert(p_title text) to risbd6_ext;
grant execute on function func_categories_on_update(p_id integer, p_title text) to risbd6_ext;
grant execute on function func_clients_on_delete(p_id integer) to risbd6_ext;
grant execute on function func_clients_on_insert(p_surname text, p_name text, p_patronymic text, p_birthdate date, p_phone text, p_email text, p_address text, p_passport_series text, p_passport_number text, p_issue_date date, p_issue_department text) to risbd6_ext;
grant execute on function func_clients_on_update(p_id integer, p_surname text, p_name text, p_patronymic text, p_birthdate date, p_phone text, p_email text, p_address text, p_passport_series text, p_passport_number text, p_issue_date date, p_issue_department text) to risbd6_ext;
grant execute on function func_companies_on_delete(p_id integer) to risbd6_ext;
grant execute on function func_companies_on_insert(p_name text, p_country_id integer, p_head_full_name text, p_phone text, p_address text, p_bank_details text) to risbd6_ext;
grant execute on function func_companies_on_update(p_id integer, p_name text, p_country_id integer, p_head_full_name text, p_phone text, p_address text, p_bank_details text) to risbd6_ext;
grant execute on function func_countries_on_delete(p_id integer) to risbd6_ext;
grant execute on function func_countries_on_insert(p_name text) to risbd6_ext;
grant execute on function func_countries_on_update(p_id integer, p_name text) to risbd6_ext;
grant execute on function func_goods_on_delete(p_id integer) to risbd6_ext;
grant execute on function func_goods_on_insert(p_category_id integer, p_company_id integer, p_model text, p_price numeric, p_description text) to risbd6_ext;
grant execute on function func_goods_on_update(p_id integer, p_category_id integer, p_company_id integer, p_model text, p_price numeric, p_description text) to risbd6_ext;
grant execute on function func_orders_on_delete(p_id integer) to risbd6_ext;
grant execute on function func_orders_on_insert(p_goods_id integer, p_client_id integer, p_on_sale_date date, p_sale_amount numeric, p_payment_method_id integer, p_sale_type_id integer, p_details text) to risbd6_ext;
grant execute on function func_orders_on_update(p_id integer, p_goods_id integer, p_client_id integer, p_on_sale_date date, p_sale_amount numeric, p_payment_method_id integer, p_sale_type_id integer, p_details text) to risbd6_ext;
grant execute on function func_search_companies_by_country(p_id integer) to risbd6_ext;
grant execute on function query06(p_month integer) to risbd6_ext;
grant execute on function query07() to risbd6_ext;
grant execute on function query81() to risbd6_ext;
grant execute on function query82(p_id integer) to risbd6_ext;
grant execute on function query83(p_id integer, p_from date, p_to date) to risbd6_ext;
grant execute on function query91() to risbd6_ext;
grant execute on function query92( p_id integer, p_from date, p_to date) to risbd6_ext;

grant execute on function get_all_categories() to risbd6_ext;
grant execute on function get_all_countries() to risbd6_ext;
grant execute on function get_all_clients() to risbd6_ext;
grant execute on function get_all_companies() to risbd6_ext;
grant execute on function get_companies_by_server(serv_id integer) to risbd6_ext;
grant execute on function get_list_countries_by_server(serv_id integer) to risbd6_ext;
grant execute on function get_list_companies_by_server(serv_id integer) to risbd6_ext;
grant execute on function get_goods_by_server(serv_id integer) to risbd6_ext;
grant execute on function get_orders_by_server(serv_id integer) to risbd6_ext;
grant execute on function get_all_sale_types() to risbd6_ext;
grant execute on function get_all_payment_methods() to risbd6_ext;
grant execute on function get_list_clients() to risbd6_ext;
grant execute on function get_list_goods_by_server(serv_id integer) to risbd6_ext;