FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    java CountBeers < "%%f" > "!file:.in.txt=.out.txt!"
)
