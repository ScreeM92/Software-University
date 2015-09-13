FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    java SumCards < "%%f" > "!file:.in.txt=.out.txt!"
)
