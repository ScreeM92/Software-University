FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    java ThreeLargestNumbers < "%%f" > "!file:.in.txt=.out.txt!"
)
