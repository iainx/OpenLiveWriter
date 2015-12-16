SOLUTION_PATH=src/managed/writer.sln
OLW_CONFIG=Debug

all:
	nuget restore $(SOLUTION_PATH)
	xbuild /nologo /tv:12.0 /p:TargetFrameworkVersion="v4.5" /p:Configuration=$(OLW_CONFIG) /p:NoWarn=0219,0414  $(SOLUTION_PATH)
