FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    java SimpleExpression < "%%f" > "!file:.in.txt=.out.txt!"
)
