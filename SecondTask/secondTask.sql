SELECT p.Name AS ProductName, c.Name AS CategoryName FROM PRODUCTS AS p 
LEFT JOIN PRODUCTS_CATEGORIES AS pc ON p.Id = pc.ProductId 
LEFT JOIN CATEGORIES AS c ON pc.CategoryId = c.Id