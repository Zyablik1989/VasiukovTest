SELECT        CUSTOMERS.NAME AS CUSTOMER_NAME, MANAGERS.NAME AS MANAGER_NAME
FROM            CUSTOMERS INNER JOIN
                         ORDERS ON CUSTOMERS.ID = ORDERS.CUSTOMER_ID INNER JOIN
                         MANAGERS ON CUSTOMERS.MANAGER_ID = MANAGERS.ID
WHERE        (ORDERS.AMOUNT > 10000) AND (ORDERS.DATE > CONVERT(DATETIME, '2013-01-01 00:00:00', 102))