MCS=gmcs
CSFLAGS=

all:	chains filehandles wtf
chains:	chains.cs
	$(MCS) chains.cs $(CSFLAGS)
filehandles:	filehandles.cs
	$(MCS) filehandles.cs $(CSFLAGS)
wtf:	wtf.cs
	$(MCS) wtf.cs $(CSFLAGS)
