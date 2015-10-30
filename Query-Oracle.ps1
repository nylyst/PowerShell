[Reflection.Assembly]::LoadFile("C:\Oracle32\product\11.1.0\client_1\odp.net\bin\2.x\Oracle.DataAccess.dll")
$query = "select * from analyses_definitionsview a where effective_datestamp = (select max(effective_datestamp) from analyses_definitionsview b where a.master_analsysinumber = b.master_analysisnumber and a.piece_analysisnumber = b.piece_analysisnumber)"
$con = New-Object Oracle.DataAccess.Client.OracleConnection("VALIDATE CONNECTION=False;USER ID=ETW06404;PASSWORD=*LFj2)34ca)E;DATA SOURCE=PARADEV;PERSIST SECURITY INFO=True;POOLING=True")
$con.Open()
$cmd = New-Object Oracle.DataAccess.Client.OracleCommand($query, $con)
$rdr = $cmd.ExecuteReader()