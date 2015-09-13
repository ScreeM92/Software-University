FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    java StuckNumbers < "%%f" > "!file:.in.txt=.out.txt!"
)
