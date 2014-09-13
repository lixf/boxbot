# Data Types

## User
```
{
  "uid": 12345,
  "firstname": Bob,
  "lastname": Chen,
  "join_date": 1235
}
```

## Bot
```
{
  "bid": 1234,
  "uid": 12345,
  "hp": 123,
  "armour": [
  ],
  "weapon1": {},
  "weapon2": {},
  "inventory": {
  }
}
```

## Prototypes
```
{
  "name": "Basic Armour",
  "type": "armour"
  // type specific fields
}
```

## Items
Items are prototypes instantiated with longitude, lattitude, iid
```
{
  "iid": "32a4fbed-676d-47f9-a321-cb2f267e2918",
  "name": "Basic Armour",
  "type": "armour",
  "lat": 79.3
  "lng": 32.4093
  // type specific fields
}
```
