FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    java Orders < "%%f" > "!file:.in.txt=.out.txt!"
)
