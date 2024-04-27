# Labb3-AvanceradDotNet
----------------------------------------------------
<h2> Hämta alla personer i systemet</h2>
<p> curl -X 'GET' \
  'https://localhost:7044/api/Person' \
  -H 'accept: */*'</p>
<p>https://localhost:7044/api/Person</p>
------------------------------------------------------------------------------
<h2>Hämta alla intressen som är kopplade till en specifik person</h2>
<p>curl -X 'GET' \
  'https://localhost:7044/api/Person/withInterests/1' \
  -H 'accept: text/plain'</p> <p>https://localhost:7044/api/Person/withInterests/1</p>
--------------------------------------------------------------------------------
<h2>Hämta alla länkar för en person</h2>
<p>curl -X 'GET' \
  'https://localhost:7044/api/Person/withLinks/1' \
  -H 'accept: text/plain'</p> <p>https://localhost:7044/api/Person/withLinks/1</p>
----------------------------------------------------------------------------------
<h2>Koppla en person till ett nytt intresse.</h2>
<p>curl -X 'POST' \
  'https://localhost:7044/api/PersonalInterest' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "personId": 1,
  "interestId": 7
}'</p>
<p>https://localhost:7044/api/PersonalInterest</p>
----------------------------------------------------------------
<h2> Lägga in ny länk för en specifik person och intresse.</h2>
<p>curl -X 'POST' \
  'https://localhost:7044/api/Link' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "url": "https://svenskfaktning.se/",
  "personalInterestId": 8
}'</p>
<p>https://localhost:7044/api/Link</p>
