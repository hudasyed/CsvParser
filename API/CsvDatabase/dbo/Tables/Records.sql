CREATE TABLE Records (
    Parent NVARCHAR(3),
    Child NVARCHAR(3),
    Quantity INT NOT NULL DEFAULT 0,
    PRIMARY KEY (Parent, Child)
);