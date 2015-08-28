select t.name, c.Name 
from 
sys.Columns c
inner join sys.tables t on t.object_id = c.object_id
where c.is_identity = 1