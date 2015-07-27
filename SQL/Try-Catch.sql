begin try
	print 'Begin transaction.'
	begin transaction
	
	--rollback transaction
	--print 'Rolled back.'
	
	commit transaction
	print 'Committed.'
	
end try
begin catch

	rollback transaction
	print 'Rolled back.'

	print (ERROR_MESSAGE());
end catch