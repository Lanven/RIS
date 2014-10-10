SELECT sb.clients.surname, sb.clients.name, sb.clients.patronymic, sb.clients.birthdate,
	sb.clients.passport_series, sb.clients.passport_number, sum(sale_amount)
FROM (SELECT id FROM sb.goods_main WHERE sb.goods_main.company_id = 220) as good
JOIN (SELECT goods_id, client_id, sale_amount FROM sb.orders_main 
	WHERE on_sale_date BETWEEN '2014-01-01' and '2014-12-31') as ordr
	ON ordr.goods_id = good.id
JOIN sb.clients ON sb.clients.id = ordr.client_id
GROUP BY sb.clients.surname, sb.clients.name, sb.clients.patronymic, sb.clients.birthdate,
	sb.clients.passport_series, sb.clients.passport_number
ORDER BY 7 DESC, (1,2,3) ASC, 4 ASC