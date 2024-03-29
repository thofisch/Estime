insert into Consultant (Id, Sku, Name) values (NEWID(), 'A', 'Thomas Wittrup Fischer')
insert into Consultant (Id, Sku, Name) values (NEWID(), 'B', 'Anders Vedel')
insert into Consultant (Id, Sku, Name) values (NEWID(), 'C', 'Rasmus Burkal')
insert into Consultant (Id, Sku, Name) values (NEWID(), 'D', 'Ole')

declare @clientId uniqueidentifier

set @clientId = NEWID()

insert into Client (Id, Name) values (@clientId, 'Chopin')
insert into Project (Id, Sku, ClientId, Name, StandardProject, DefaultTaskStatus) values (NEWID(), 'AA', @clientId, 'Std', 1, 0)

insert into [Ware] (Id, Sku, Name) values (NEWID(), '200-Addgb', 'Online Backup Dataforbrug')
insert into [Ware] (Id, Sku, Name) values (NEWID(), '200-fileserver', 'Online Backup Server node')
insert into [Ware] (Id, Sku, Name) values (NEWID(), '200-inital', 'Online Backup Oprettelse')
insert into [Ware] (Id, Sku, Name) values (NEWID(), '200-initial', 'Backup Oprettelse ekstra node')
insert into [Ware] (Id, Sku, Name) values (NEWID(), '200-mail_db', 'Remote Backup Mail server Licens')
insert into [Ware] (Id, Sku, Name) values (NEWID(), '200-subscription', 'Online Backup Abn.')
insert into [Ware] (Id, Sku, Name) values (NEWID(), '200-tlfsupp', 'Remote Backup Basic Telefon support')
insert into [Ware] (Id, Sku, Name) values (NEWID(), '200-workstation', 'Online Backup workstation Node')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'APC-Div', 'APC Batteri')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'APC-UPS-DIV', 'APC Smart-UPS 1500 SC')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'APPL-Div', 'Apple ')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'APPL-OSX', 'Mac OS X 10.6 Snow Leopard')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'AXI-M1011', 'Axis CAM M1011')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'AXIS-CAM-DIV', 'Axis Netw�rks Kamera')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'Axis-Div', 'Axis Diverse')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'BROTHER-Toner', 'Brother Toner')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'Canon-Toner', 'Canon Toner')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'Cert-Multi-3�r', 'Certifikat Multi 3�r')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'Cert-singel-3�r', 'Certifikat 3 �r')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'CIS-SD205T SWITCH', 'Cisco SD205T 5-Port Switch 10/100Mbps')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'CIS-SR2016T', 'Cisco SR2016T 16-Port Gigabit rackmount')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'CIS-WAP610N', 'Cisco Wireless WAP610N-EU')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'COME-Div', 'Sikkerhedspakke')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'CON-Advanced', 'Advanced PHP Webhotel')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'CON-Div', 'Conviator Diverse')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'CON-DK-DOM', 'K�b af .dk')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'CON-HE500', 'Exchange 2007, 500mb')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'CON-MiniWeb', 'Web- & Mailhotel')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'CURA-Div', 'Curanet Hosting produkter')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'CURA-DNS', 'Curanet DNS hosting')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'CURA-HE-1G', 'Hosted Exchange 1Gb, 3md')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'CURA-HE-3G', 'Hosted Exchange 3Gb, 3md')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'CURA-HE-Outlook', 'Hosted Exchange Outlook licens, 3md')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'CURA-Hosting', 'Curanet Hosting pakker')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'CURA-ProWeb', 'Pro Webhotel')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'CURA-SafeMode', 'Pro Webhotel - safemode off')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'CURA-StdWeb', 'Standard Webhotel')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'D-Link-Div', 'D-Link Hardware')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'DELL-21,5in', 'Dell Monitor 21,5in U2212HM')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'DELL-22in', 'Dell Monitor 22in 2209WA')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'DELL-24''', 'Dell Monitor P2411H')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'DELL-27in', 'Dell Monitor 27in U2711 ')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'DELL-Div', 'Dell')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'DELL-LAT-6320', 'Dell Lattitude E6320')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'DELL-LAT-E6220', 'Dell Lattitude E6220')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'DELL-LAT-E6410', 'Dell Lattitude E6410')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'DELL-OPTIPLEX 790', 'Dell Optiplex 790 USFF')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'DELL-P-REP', 'Dell Port Replicator')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'DELL-PS/2', 'Dell Ps/2 adapter')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'DIV-H�NDSCANNER', 'H�ndscanner, DL Cable CAB-412')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'DIV-HARDWARE', 'Diverse hardware')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'DIV-RAM', 'Diverse ram mm.')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'DIV-YDELSER', 'Diverse ydelser')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-DAG-AV', 'Teknisk assistance 1 Dag')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-DAG-RB', 'Teknisk assistance 1 Dag')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-DAG-RHJ', 'Teknisk assistance 1 Dag')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-Div', 'Diverse hardware')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-Ekstern', 'Ekstern konsulent ydelse')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-FP-Hosting', 'Server Hosting')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-Hos-Nas', 'Hostet NAS 1 TB')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-Klar-Pc', 'PC / B�rbar Klarg�ring')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-NET-0,5M', 'Netv�rks Kabel 0,5 M')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-NET-1.5', 'Netv�rks kabel 1,5M')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-NET-10M', 'Netv�rks Kabler 10 M')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-Net-1M', 'Netv�rks Kabel 1 M')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-NET-2M', 'Netv�rks Kabel 2 M')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-NET-3M', 'Netv�rks Kabel 3M')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-NET-5M', 'Netv�rkskabler 5 M')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-NET-Fiber', 'Netv�rks Kabel Fiber 1 M')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-ONLINE-RHJ', 'Onlinesupport Ren�')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-Service-Abn', 'Servicekontrakt Abn. 1. Server')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-Service-Abn2', 'ServiceKontrakt Abn for ekstra server')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-Service-lite', 'Server Servicekontrakt Lite')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-SUP', 'Konsulent arbejde')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-SUP-AV', 'Konsulent arbejde')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-SUP-FREE', 'Konsulent arbejde af freelancer')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-SUP-OMH', 'Konsulent arbejde')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-SUP-RB', 'Konsulent arbejde')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-SUP-RHJ', 'Konsulent arbejde')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'Ex-Supp-Klip100', '100 timers klippekort p� konsulentarbejd')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-Supp-Klip30', '30 timers klippekort p� konsulentarbejde')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-Supp-Klip40', 'Klippekort p� Konsulentarbejde')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'Ex-Supp-Klip50', '50 timers klippekort p� konsulentarbejde')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-SWATCH-FP', 'Support, Drift og Overv�gning')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-SWATCH-NW', 'Overv�gning abn. pr netv�rks enhed')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-SWATCH-SRV', 'Overv�gning abn. pr. server')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'ex-telefonsup', 'IT Telefonsupport')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-TLF-AV', 'Telefonsupport')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-TLF-Bruger', 'IT tlf. abb. tilknyttet superbruger')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-TLF-RB', 'Telefonsupport')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-TLF-RHJ', 'Telefonsupport')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-TLF-SUP', 'IT tlf. abb. for superbrugere i dagt.')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-TRYG-Basis', 'Tryghedsaftale Basis')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-TRYG-Pro', 'Tryghedsaftale Pro')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-TRYG-Standard', 'Tryghedsaftale Standard')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'EX-Udg�et', 'Udg�et vare')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'Fragt', 'Fragt')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'FS-100GB', '100 GB data pakke')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'FS-20GB', 'Online Backup 20Gb till�g')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'FS-250GB', 'Online Backup 250GB Pakke')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'FS-400GB', '400 GB data pakke')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'FS-Basis', 'Online Backup Basis inkl. 20Gb')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'FS-FP', 'Online Backup')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'FS-Node', 'Node inkl. overv. og tlf. support')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'HOST-Div', 'Hosting videresalg')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'HOST-FP', 'ServerHosting Samlet server l�sning')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'Host-Samlet', 'Hosting pakke')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'HOST-SIKK', 'Hosting af sikkerhedsudstyr')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'HOST-STR�M', 'Str�mforbrug Hostingcenter')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'HOST-TrafInt', 'Hosting Trafik International')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'HOST-TrafNat', 'Hosting Trafik National')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'HOST-UNIT', 'Hosting per unit')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'HP-CP2025n', 'HJ LaserJet CP2025n Color')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'HP-Div', 'HP diverse')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'HP-LJP1102', 'HP Laserjet P1102')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'HP-LJP2055dn', 'HP Laserjet P2055dn')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'HP-M3027', 'HP LaserJet M3027 MFP')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'HP-Toner', 'HP Toner')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'HP-V1410', 'Switch 24 Ports')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'IBM-', 'Standard')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'IBM-Div', 'IBM Diverse')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'IBM-Server', 'IBM Server')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'JUN-Div', 'Juniper Diverse')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'JUN-JCare', 'Juniper J-Care 3 �r')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'JUN-SRX100', 'Juniper SRX100B')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'JUN-SSG-5', 'Juniper SSG-5 Firewall')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'k�rsel', 'K�rsel')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LBL-34X25', 'Labels Hvid 34 x 25 1000 stk')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LBL-50X24', 'Labels Hvid 50 x 24 1000 stk')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LBL-54X70', 'Labels Hvid 54 x 70 rulle')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LENO-Div', 'Lenovo')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LENO-DOCK', 'ThinkPad Dock')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LENO-KEYB', 'Lenovo USB Keyboard')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LENO-M58P', 'Lenovo ThinkCenter M58P')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LENO-M70e', 'Lenovo ThinkCenter M70e Tower')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LENO-M71e', 'Lenovo ThinkCenter M71e')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LENO-M81 i3', 'Lenovo M81 i3 2100/1x2')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LENO-M90', 'Lenovo ThinkCenter M90 USFF')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LENO-M90p', 'Lenovo M90p i5-560')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LENO-T410', 'Lenovo ThinkPad T410')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LENO-T410S', 'Lenovo ThinkPad T410S')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LENO-T420S', 'Lenovo Thinkpad T420S')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LENO-T520', 'Lenovo Thinkpad T520')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LENO-X220', 'Lenovo ThinkPad x220 i5-2520M')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LEX-Toner', 'Lexmark Toner')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LOGI-Div', 'Logitech div')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LOGI-MK250', 'Logitech MK250 Keyboard S�t')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'LOGI-MK320', 'Logitech MK320 Keyboard s�t')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MELBOURNE-DOM', 'Melbourne dom�ner')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MIC-CAL-MOL', 'Microsoft Windows CAL MOL Aftale')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MIC-Div-HW', 'Microsoft div hardware')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MIC-Div-SW', 'Microsoft div software')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MIC-OFF-MOL', 'Microsoft Office Std licens MOL aftale')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MIC-OFF-MOL-Pro', 'Microsoft Office Pro licens MOL aftale')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MIC-OFF-OV', 'Microsoft Office Licens OV aftale')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MIC-RD-Cal', 'Microsoft RD Cal licens OV aftale')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MIC-RD-CAL-MOL', 'Microsoft RD Cal MOL Aftale')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MIC-SQL-WORK-Cal-Mol', 'Microsoft SQL Workgroup Cal licens')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MIC-SQL-Work-MOL', 'Microsoft SQL server Workgroup 5 cal')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MIC-SRV-MOL', 'Microsoft Server 2008R2 Mol aftale')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MICR-228-04685', 'SQL Server Standard SA')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MICR-359-01479', 'SQL User CAL SA')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MICR-6vc-00705', 'Windows RemoteDesktop Cal SA')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MICR-Off-Lic-sa-OV-3', 'Microsoft Office Singel LIC/SA OV 3�r')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MICR-Office2010HBPKC', 'MS office 2010 HomeandBusiness PCK ')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MICR-Office2011', 'MS office 2010 HomeandBusiness Box')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MICR-P73-01423', 'Windows Server Standard SA')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MICR-R18-01863', 'Windows Server Cal SA')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MICR-RD-CAL-LIC-SA-3', 'Microsoft RemoteDesktop Cal LIC/SA OV 3�')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MICR-SBS-ESSEN', 'MicrosoftSBS 2011 Essentials')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MICR-Win2008R2-OEM', 'Microsoft Windows 2008 R2 OEM')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MICR-Win2008R2Oem-Ca', 'Microsoft Windows 2008R2 Oem 5 CAL ')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MICR-WIN7-OEM', 'Microsoft 7 Professional 32bit DK OEM')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'MOSP', 'MOSP Partner of Record Fee')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'QNAP', 'QNAP')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'QNAP-219P', 'QNAP TS-219PII')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'SEAGATE-B', 'Seagate Barracuda 1TB')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'standard', 'Standard')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'Transport', 'Transport/Fragt')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'USR-Div', 'US Robotics Modem')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'WD-NAS', 'WD Sentinel DX4000 NAS HDD 4TB')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'WD-USB-DISC', 'WD Essential USB Disk')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'WG-Dom�ne', '.com fornyelse')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'ZYXE-AG200', 'Zyxel AG-220 Wireless Client USB Adapter')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'ZYXE-DIM-GS108B', 'Zyzel Dimension GS-108B')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'ZYXE-Dim-GS2200', 'Zyxel GS-2200 24P Switch')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'ZYXE-DIV', 'Zyxel Div')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'Zyxe-GS108', 'Zyxel GS-108B Switch')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'ZYXE-NWA-3160N', 'Zyxel NWA-3160N Accesspoint')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'ZYXE-NWA-3166', 'Zyxel NWA-3166 Accesspoint')
insert into [Ware] (Id, Sku, Name) values (NEWID(), 'ZYXE-WAP3205', 'Zyxel WAP3205 Access Point')
