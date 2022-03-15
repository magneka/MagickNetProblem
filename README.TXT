Bug report:

I am trying to use Magic.Net.Core insida an AWS Lambda function to convert images, 
but a large number of the images fails due to a problem with custom tags.

MAGIC.NET
---------
When loading the image, i get some sanity check error, or Can not read TIFF directory count.
This happens on 50% of the files i have tried.

TIFFINFO
--------
Using the linux tool tiffinfo, it also reports the same error.

IMAGE APPLICATIONS
------------------
However image applications (gimp, ms paint etc.) seems to read the file.

USING "convert"
--------------
However, using convert like this:

C:\magnea\ReproduceError>convert FileWithcustomTag.TIFF FileWithcustomTag.jpg

gives output:
convert: Unknown field with tag 34152 (0x8568) encountered. `TIFFReadDirectory' @ warning/tiff.c/TIFFWarnings/956.
convert: Sanity check on directory count failed, this is probably not a valid IFD offset. `TIFFFetchDirectory' @ error/tiff.c/TIFFErrors/596.
convert: Failed to read custom directory at offset 63112580. `TIFFReadCustomDirectory' @ error/tiff.c/TIFFErrors/596.
convert: Unknown field with tag 34152 (0x8568) encountered. `TIFFReadDirectory' @ warning/tiff.c/TIFFWarnings/956.
convert: improper image header `FileWithcustomTag.TIFF' @ error/psd.c/ReadPSDLayersInternal/2020.

But: it produces a file which is OK.

