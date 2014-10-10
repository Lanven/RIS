SELECT * FROM public.dblink ('dbname=risbd6 host=students.ami.nstu.ru 
port=5432 user=risbd6 password=ris14bd6', 
'SELECT sa.categories.title, good.model, sa.payment_methods.title, sum(sale_amount)
FROM (SELECT id, category_id, model FROM sa.goods_main WHERE company_id = 1) as good
JOIN sa.categories ON sa.categories.id = good.category_id
JOIN sa.orders_main ON sa.orders_main.goods_id = good.id
JOIN sa.payment_methods ON sa.payment_methods.id = sa.orders_main.payment_method_id 
WHERE on_sale_date BETWEEN ''2014-01-01'' and ''2014-12-31''
GROUP BY sa.categories.title, good.model, sa.payment_methods.title
ORDER BY 4 DESC, 1 ASC') as summa (categories_title text, model text, payment_methods_title text, summa numeric(12,2))
