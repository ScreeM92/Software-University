FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    java Durts < "%%f" > "!file:.in.txt=.out.txt!"
)
