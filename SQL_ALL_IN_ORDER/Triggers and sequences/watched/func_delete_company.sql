--DROP FUNCTION func_distribution_company_on_delete(integer);

CREATE OR REPLACE FUNCTION func_distribution_company_on_delete(p_id integer) RETURNS void AS $$
BEGIN

if (select count(*) from sb.companies a where a.id=p_id)=0
then 
raise notice '111';
perform dblink_connect ('dbname=risbd6 host=students.ami.nstu.ru 
			port=5432 user=risbd6 password=ris14bd6');
perform dblink_exec ('DELETE FROM sa.companies WHERE id='||p_id||';');

perform dblink_disconnect();

else DELETE FROM sb.companies WHERE id=p_id; raise notice '222';
end if;

return;
END
$$ LANGUAGE plpgsql;

--select func_distribution_company_on_delete(606);
