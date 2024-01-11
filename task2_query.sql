/*
    Пусть имеется таблица продукты - 'Products' и категории - 'Categories'.
    В каждой из них имеется атрибуты 'Id int PRIMARY KEY' и 'varchar(255)'
    Учитывая, что отношение между категориями и продуктами - many-to-many, 
    существует промежуточная таблица для их связи (предположим, что это 'ProductCategories'). 
    Пусть PrimaryKey таблицы 'ProductCategories' будет состоять из набора атрибутов 'Id' таблиц 'Products' и 'Categories' (как FK).
    Тогда запрос для выбора всех пар «Имя продукта – Имя категории» выглядит следующим образом:
*/

SELECT P.Name as ProductName, C.Name as CategoryName
FROM Products P
     LEFT JOIN ProductCategories PC
               ON P.Id = PC.ProductId
     LEFT JOIN Categories C
               ON PC.CategoryId = C.Id;

/*
    Примечание: используя LEFT JOIN по таблице 'Products' выводится всё множество строк 'Products', даже если у продукта нет категорий. 
*/