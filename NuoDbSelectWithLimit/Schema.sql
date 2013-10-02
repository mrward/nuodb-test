
DROP TABLE IF EXISTS "recent_winners" CASCADE;

CREATE TABLE "recent_winners" 
("id" INTEGER NOT NULL, 
"game_name" VARCHAR(150) NOT NULL, 
"amount" DECIMAL(10,2) NOT NULL, 
"won_at" TIMESTAMP NOT NULL, 
"site_id" INTEGER NOT NULL);
