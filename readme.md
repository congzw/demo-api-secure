# demo for aspnet core api security

## history

- thick client app : windows authentication
- server-side web app : windows or forms authentication
- service-based app: WS-Security(WCF)


- user/password security
- token-based security


## token security

- token expireation
- token sign and vaidate
- token format
- authen & author
- diff app types
- ...

## Vocabulary

- IDP: Identity Provider
- IAM: Identity Access Management
- OAuth2: an open protocol to allow secure authorization standard for: web, mobile, desktop apps.
- OIDC: OpenId Connect: a simple identity layer on top of OAuth2 protocol

## how to use?

- start project =>  ~/
- Create Token With "Basic Auth" Or "JWT"
- use Postman Test With Headers:
	- 1 Authorization: Bearer {TheToken}
	- 2 Authorization: Basic {TheToken}

## change list

- 20201112 add cookies demo
- 20201112 add default identity demo
- 20200904 add jwt auth demo
- 20200904 add basic auth demo
- 20200904 init projects