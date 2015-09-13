FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    java StraightFlush < "%%f" > "!file:.in.txt=.out.txt!"
)
