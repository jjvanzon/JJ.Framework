select e.ID from MyEntity
where 
  (@categoryID is null or e.CategoryID = @categoryID) and
  (@kind is null or e.Kind = @kind) and
  (@minStartDate is null or e.MinStartDate >= @minStartDate);
