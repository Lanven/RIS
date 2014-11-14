SELECT sb.categories.title, a.model, sb.payment_methods.title, summ
from
(
SELECT good.category_id, good.model, orders.payment_method_id, sum(orders.sale_amount) as summ
FROM (SELECT id, category_id, model 
	FROM sb.goods_main 
	WHERE company_id = 220) as good
JOIN (SELECT goods_id, payment_method_id, sale_amount
	FROM sb.orders_main 
	WHERE on_sale_date BETWEEN '2014-01-01' and '2014-12-31') AS orders
	ON orders.goods_id = good.id
GROUP BY good.category_id, good.model, orders.payment_method_id	
)as a
JOIN sb.categories ON sb.categories.id = a.category_id
JOIN sb.payment_methods ON sb.payment_methods.id = a.payment_method_id 

ORDER BY 4 DESC, 1 ASC
