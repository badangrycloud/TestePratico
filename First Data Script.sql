INSERT INTO ContaCorrente (Id, Agencia, NumeroConta, Digito)
Values (NEWID(),'5207','000000000015489','02'),
	   (NEWID(),'4521','000000000015145','05'),
	   (NEWID(),'9512','000000000026841','12'),
	   (NEWID(),'3546','000000000038748','41'),
	   (NEWID(),'5046','000000000042663','09')

INSERT INTO Lancamento (Id, ContaCorrenteId, TipoOperacao, DataOperacao, Valor)
SELECT NEWID(), CC.Id, 'Credito',GETDATE(), 1000 FROM ContaCorrente CC