<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                              xmlns:fo="http://www.w3.org/1999/XSL/Format" >
	<xsl:output method="text" omit-xml-declaration="no" indent="no"/>
	<xsl:template match="/">
		<xsl:for-each select="//Car">
			<xsl:value-of select="@VIN"/>
			<xsl:value-of select="@ProductionYear" />
			<xsl:value-of select="concat(VIN ,',' , ProductionYear, ',' , Model, '&#xa;')"/>
		</xsl:for-each>			
	</xsl:template>
</xsl:stylesheet>