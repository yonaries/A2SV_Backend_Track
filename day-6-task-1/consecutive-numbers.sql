SELECT DISTINCT lgt1.num AS ConsecutiveNums
FROM 
    Logs lgt1,Logs lgt2, Logs lgt3
WHERE
    lgt1.Id = lgt2.Id - 1 AND lgt2.Id = lgt3.Id - 1
    AND lgt1.num = lgt2.num AND lgt2.num = lgt3.num;
