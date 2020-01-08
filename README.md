# MarketPlace

Integrações feitas até o momento.

  - Gloria Food
  - Ifood

# Gloria Food

Links importantes:
  - https://www.gloriafood.com/pt-br
  - https://github.com/GlobalFood/integration_docs/blob/master/accepted_orders/version_1/ORDER.md

Para fazer a integração com o gloria food é preciso de algumas informações, criei um arquivo json "MarketPlace.json" no Disco "C:\"  que o aplicativo de exemplo ler, essas informações cada SoftHouse e restaurante tem.  

```sh
{
	Gloria: {
		Token: "Coloca aqui o token"
	}
}
```

# Ifood

Links importantes:
  - https://developer.ifood.com.br/reference#oauthtoken
  - https://portal.ifood.com.br/home

Para fazer a integração com ifood é preciso de algumas informações, criei um arquivo json "MarketPlace.json" no Disco "C:\"  que o aplicativo de exemplo ler, essas informações cada SoftHouse e restaurante tem.  

```sh
{
	Ifood: {
		Client_ID: "coloca aqui o client_id da SH",
		Client_SECRET: "coloca aqui o client_secret da SH",
		MerchantId: "coloca aqui o MerchantId do restaurante",
		Usuario: "coloca aqui o Usuario do restaurante",
		Senha: "coloca aqui o Senha do restaurante"
	}
}
```

