#These Links Do Not Work. These Are Just Examples of the Queries.

#Query Web

http://abcuniversity/_api/site

#Query List

http://abcuniversity/_api/web/lists/getByTitle('Chemicals')

#Query Items

http://abcuniversity/_api/web/lists/getByTitle('Chemicals')/items

#Query Item 1

http://abcuniversity/_api/web/lists/getByTitle('Chemicals')/items(1)

#oData $select

http://abcuniversity/_api/web/lists/getByTitle('Chemicals')/items?$select=Title,Element_x002d_Name

#oData $select $order

http://abcuniversity/_api/web/lists/getByTitle('Chemicals')/items?$select=Title,Element_x002d_Name&$order=Element_x002d_Name

#oData $select $filter

http://abcuniversity/_api/web/lists/getByTitle('Chemicals')/items?$select=Title,Element_x002d_Namehttp://abcuniversity/_api/web/lists/getByTitle('Chemicals')/items?$filter=startswith(Title,'Ox');