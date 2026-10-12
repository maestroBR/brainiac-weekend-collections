# Coleções Brainiac para WeekendDrops

Addon opcional para usar os 30 itens do Brainiac Collectibles em três coleções do Weekend. Requer SPT 4.1.6, Brainiac Collectibles 1.2.0 e WeekendDrops 1.0.7.

Extraia o ZIP na pasta do SPT. Ele cria apenas `SPT_Runtime/user/mods/Brainiac-WeekendCollections`.

O addon lê `collections.json` da própria pasta e acrescenta conjuntos ao serviço de coleções em memória. O `collection.json` do Weekend não é sobrescrito. IDs existentes são mantidos; recarregar a configuração do Weekend reaplica os conjuntos sem duplicá-los.

O mod principal continua responsável pelos itens, loot e bundles. Este pacote não contém os modelos e não instala o WeekendDrops. Para remover, retire a pasta do addon com o servidor fechado e reinicie.
