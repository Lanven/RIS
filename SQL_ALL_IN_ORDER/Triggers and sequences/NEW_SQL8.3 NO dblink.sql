SELECT sb.categories.title, good.model, sb.payment_methods.title, sum(sale_amount)
FROM (SELECT id, category_id, model FROM sb.goods_main WHERE company_id = 220) as good
JOIN sb.categories ON sb.categories.id = good.category_id
JOIN sb.orders_main ON sb.orders_main.goods_id = good.id
JOIN sb.payment_methods ON sb.payment_methods.id = sb.orders_main.payment_method_id 
WHERE on_sale_date BETWEEN '2014-01-01' and '2014-12-31'
GROUP BY sb.categories.title, good.model, sb.payment_methods.title
ORDER BY 4 DESC, 1 ASC
