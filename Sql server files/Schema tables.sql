--- Get conn string
select
    'data source=' + @@servername +
    ';initial catalog=' + db_name() +
    case type_desc
        when 'WINDOWS_LOGIN' 
            then ';trusted_connection=true'
        else
            ';user id=' + suser_name() + ';password=<<YourPassword>>'
    end
    as ConnectionString
from sys.server_principals
where name = suser_name()


CREATE table product (

	id INT IDENTITY(1,1),
	description varchar(500) NOT NULL,
	value decimal(10,2) NOT NULL,
	notes varchar(200) NULL
)

INSERT INTO product(description,value,notes)
values 
('Big Mac',10.99,'Best burger'),
('Sundae',4.49,NULL)


SELECT * FROM product



