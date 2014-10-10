SELECT * FROM(
SELECT sa.categories.title, good.model, sa.payment_methods.title, sum(sale_amount)
FROM (SELECT id, category_id, model FROM sa.goods_main WHERE company_id = 1) as good
JOIN sa.categories ON sa.categories.id = good.category_id
JOIN sa.orders_main_less ON sa.orders_main_less.goods_id = good.id
JOIN sa.payment_methods ON sa.payment_methods.id = sa.orders_main_less.payment_method_id 
WHERE on_sale_date BETWEEN '2014-01-01' and '2014-12-31'
GROUP BY sa.categories.title, good.model, sa.payment_methods.title

UNION

SELECT sa.categories.title, good.model, sa.payment_methods.title, sum(sale_amount)
FROM (SELECT id, category_id, model FROM sa.goods_main WHERE company_id = 1) as good
JOIN sa.categories ON sa.categories.id = good.category_id
JOIN sa.orders_main_more ON sa.orders_main_more.goods_id = good.id
JOIN sa.payment_methods ON sa.payment_methods.id = sa.orders_main_more.payment_method_id 
WHERE on_sale_date BETWEEN '2014-01-01' and '2014-12-31'
GROUP BY sa.categories.title, good.model, sa.payment_methods.title
) as a
ORDER BY 4 DESC, 1 ASC
