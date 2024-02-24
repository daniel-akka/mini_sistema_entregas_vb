--
-- PostgreSQL database dump
--

-- Dumped from database version 9.5.25
-- Dumped by pg_dump version 9.5.25

-- Started on 2023-05-26 16:23:38

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 1 (class 3079 OID 12355)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2344 (class 0 OID 0)
-- Dependencies: 1
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


--
-- TOC entry 217 (class 1255 OID 16594)
-- Name: altera_estoque_produto_del_saida(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.altera_estoque_produto_del_saida() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN

IF (old.devolvido = false) THEN
	UPDATE produto SET estoque = (estoque + old.quantidade) WHERE id = old.produto_id;
	RETURN NEW;
END IF;
RETURN NULL;	
END;
$$;


ALTER FUNCTION public.altera_estoque_produto_del_saida() OWNER TO postgres;

--
-- TOC entry 219 (class 1255 OID 16598)
-- Name: altera_estoque_produto_insert_saida(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.altera_estoque_produto_insert_saida() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN

	UPDATE produto SET estoque = (estoque - new.quantidade), data_saida = new.data_saida WHERE id = new.produto_id;
	RETURN NEW;	
END;
$$;


ALTER FUNCTION public.altera_estoque_produto_insert_saida() OWNER TO postgres;

--
-- TOC entry 218 (class 1255 OID 16596)
-- Name: altera_estoque_produto_update_saida(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.altera_estoque_produto_update_saida() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN

IF (new.devolvido = true) AND (old.devolvido = false) THEN
	UPDATE produto SET estoque = (estoque + old.quantidade) WHERE id = old.produto_id;
	RETURN NEW;
ELSIF (new.devolvido = false) AND (old.devolvido = true) THEN
	UPDATE produto SET estoque = (estoque - old.quantidade) WHERE id = old.produto_id;	
	RETURN NEW;
END IF;

IF (new.finalizado = true) AND (old.finalizado = false) THEN
	UPDATE produto SET data_entrega = new.data_entrega  WHERE id = old.produto_id;
	RETURN NEW;
ELSIF (new.finalizado = false) AND (old.finalizado = true) THEN
	UPDATE produto SET data_entrega = NULL WHERE id = old.produto_id;
	RETURN NEW;
END IF;

RETURN NULL;	
END;
$$;


ALTER FUNCTION public.altera_estoque_produto_update_saida() OWNER TO postgres;

--
-- TOC entry 235 (class 1255 OID 17623)
-- Name: movimentacao_produto_delete_produto(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.movimentacao_produto_delete_produto() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN

INSERT INTO movimentacao_produto(
            id, data_movimentacao, produto_id, produto_nome, fornecedo_id, 
            fornecedor_nome, entregador_id, entregador_nome, descricao)
    VALUES (DEFAULT, CURRENT_TIMESTAMP, old.id, old.descricao, old.fornecedor_id, 
            old.fornecedor_nome, 0, '', 'DELETADO O PRODUTO');

RETURN NEW;	
END;
$$;


ALTER FUNCTION public.movimentacao_produto_delete_produto() OWNER TO postgres;

--
-- TOC entry 232 (class 1255 OID 17609)
-- Name: movimentacao_produto_insert(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.movimentacao_produto_insert() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN

INSERT INTO movimentacao_produto(
            id, data_movimentacao, produto_id, produto_nome, fornecedo_id, 
            fornecedor_nome, entregador_id, entregador_nome, descricao)
    VALUES (DEFAULT, CURRENT_TIMESTAMP, new.produto_id, new.produto_descricao, new.fornecedor_id, 
            new.fornecedor_nome, new.entregador_id, new.entregador_nome, 'SAIDA DE PRODUTO');

RETURN NEW;	
END;
$$;


ALTER FUNCTION public.movimentacao_produto_insert() OWNER TO postgres;

--
-- TOC entry 234 (class 1255 OID 17621)
-- Name: movimentacao_produto_insert_entrada(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.movimentacao_produto_insert_entrada() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN

INSERT INTO movimentacao_produto(
            id, data_movimentacao, produto_id, produto_nome, fornecedo_id, 
            fornecedor_nome, entregador_id, entregador_nome, descricao)
    VALUES (DEFAULT, CURRENT_TIMESTAMP, new.produto_id, new.descricao_produto, new.fornecedor_id, 
            new.fornecedor_nome, 0, '', 'ENTRADA DE PRODUTO');

RETURN NEW;	
END;
$$;


ALTER FUNCTION public.movimentacao_produto_insert_entrada() OWNER TO postgres;

--
-- TOC entry 233 (class 1255 OID 17611)
-- Name: movimentacao_produto_update(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.movimentacao_produto_update() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN

IF (new.devolvido = true) AND (old.devolvido = false) THEN
	--SE FOI FEITO UMA DEVOLUCAO:
	INSERT INTO movimentacao_produto(
            id, data_movimentacao, produto_id, produto_nome, fornecedo_id, 
            fornecedor_nome, entregador_id, entregador_nome, descricao)
	VALUES (DEFAULT, CURRENT_TIMESTAMP, new.produto_id, new.produto_descricao, new.fornecedor_id, 
            new.fornecedor_nome, new.entregador_id, new.entregador_nome, 'DEVOLUÇÃO DO PRODUTO');

	RETURN NEW;

ELSIF (new.devolvido = false) AND (old.devolvido = true) THEN
	--SE SAIU DA DEVOLUCAO PARA ENTREGAR PARA DESTINATARIO:
	INSERT INTO movimentacao_produto(
            id, data_movimentacao, produto_id, produto_nome, fornecedo_id, 
            fornecedor_nome, entregador_id, entregador_nome, descricao)
	VALUES (DEFAULT, CURRENT_TIMESTAMP, new.produto_id, new.produto_descricao, new.fornecedor_id, 
            new.fornecedor_nome, new.entregador_id, new.entregador_nome, 'SAIDA DO PRODUTO');	
	RETURN NEW;

END IF;

IF (new.finalizado = true) AND (old.finalizado = false) THEN
	--SE O PRODUTO FOI ENTREGUE!:
	INSERT INTO movimentacao_produto(
            id, data_movimentacao, produto_id, produto_nome, fornecedo_id, 
            fornecedor_nome, entregador_id, entregador_nome, descricao)
	VALUES (DEFAULT, CURRENT_TIMESTAMP, new.produto_id, new.produto_descricao, new.fornecedor_id, 
            new.fornecedor_nome, new.entregador_id, new.entregador_nome, 'ENTREGA DO PRODUTO REALIZADA');	
	RETURN NEW;

ELSIF (new.finalizado = false) AND (old.finalizado = true) THEN
	--SE DESFEZ A ENTREGA DO PRODUTO!:
	INSERT INTO movimentacao_produto(
            id, data_movimentacao, produto_id, produto_nome, fornecedo_id, 
            fornecedor_nome, entregador_id, entregador_nome, descricao)
	VALUES (DEFAULT, CURRENT_TIMESTAMP, new.produto_id, new.produto_descricao, new.fornecedor_id, 
            new.fornecedor_nome, new.entregador_id, new.entregador_nome, 'DESFEITO A ENTREGA DO PRODUTO');	
	RETURN NEW;
	
END IF;


RETURN NULL;	
END;
$$;


ALTER FUNCTION public.movimentacao_produto_update() OWNER TO postgres;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 192 (class 1259 OID 16462)
-- Name: cidade; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.cidade (
    id bigint NOT NULL,
    nome character varying NOT NULL,
    distancia_km real DEFAULT 0 NOT NULL
);


ALTER TABLE public.cidade OWNER TO postgres;

--
-- TOC entry 191 (class 1259 OID 16460)
-- Name: cidade_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.cidade_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.cidade_id_seq OWNER TO postgres;

--
-- TOC entry 2345 (class 0 OID 0)
-- Dependencies: 191
-- Name: cidade_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.cidade_id_seq OWNED BY public.cidade.id;


--
-- TOC entry 213 (class 1259 OID 17585)
-- Name: comissao_fornecedor_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.comissao_fornecedor_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.comissao_fornecedor_id_seq OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 17587)
-- Name: comissao_fornecedor; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.comissao_fornecedor (
    id bigint DEFAULT nextval('public.comissao_fornecedor_id_seq'::regclass) NOT NULL,
    data_pagamento date DEFAULT ('now'::text)::date NOT NULL,
    fornecedor_id bigint NOT NULL,
    fornecedor_nome character varying NOT NULL,
    valor_pago real NOT NULL,
    observacao character varying
);


ALTER TABLE public.comissao_fornecedor OWNER TO postgres;

--
-- TOC entry 194 (class 1259 OID 16479)
-- Name: configuracoes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.configuracoes (
    id bigint NOT NULL,
    tipo_comissao character varying(1) DEFAULT 'F'::character varying NOT NULL,
    iniciais_produtos character varying
);


ALTER TABLE public.configuracoes OWNER TO postgres;

--
-- TOC entry 2346 (class 0 OID 0)
-- Dependencies: 194
-- Name: COLUMN configuracoes.tipo_comissao; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public.configuracoes.tipo_comissao IS 'E - Usa o Campo Comissao no Cadastro do Entregador
F - Usa o Campo Comissao no Cadastro do Fornecedor
P - Usa o Campo Comissao no Cadastro do Produto';


--
-- TOC entry 2347 (class 0 OID 0)
-- Dependencies: 194
-- Name: COLUMN configuracoes.iniciais_produtos; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public.configuracoes.iniciais_produtos IS 'ADR|SSF|ASDD';


--
-- TOC entry 193 (class 1259 OID 16477)
-- Name: configuracoes_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.configuracoes_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.configuracoes_id_seq OWNER TO postgres;

--
-- TOC entry 2348 (class 0 OID 0)
-- Dependencies: 193
-- Name: configuracoes_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.configuracoes_id_seq OWNED BY public.configuracoes.id;


--
-- TOC entry 202 (class 1259 OID 16618)
-- Name: descricao_rota; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.descricao_rota (
    id bigint NOT NULL,
    descricao character varying NOT NULL
);


ALTER TABLE public.descricao_rota OWNER TO postgres;

--
-- TOC entry 201 (class 1259 OID 16616)
-- Name: descricao_rota_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.descricao_rota_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.descricao_rota_id_seq OWNER TO postgres;

--
-- TOC entry 2349 (class 0 OID 0)
-- Dependencies: 201
-- Name: descricao_rota_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.descricao_rota_id_seq OWNED BY public.descricao_rota.id;


--
-- TOC entry 207 (class 1259 OID 17525)
-- Name: desp_produto_dpid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.desp_produto_dpid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.desp_produto_dpid_seq OWNER TO postgres;

--
-- TOC entry 208 (class 1259 OID 17527)
-- Name: desp_produto; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.desp_produto (
    dpid bigint DEFAULT nextval('public.desp_produto_dpid_seq'::regclass) NOT NULL,
    dpdescricao character varying DEFAULT 'despesa'::character varying NOT NULL,
    dpporcentagem real DEFAULT 0.00 NOT NULL
);


ALTER TABLE public.desp_produto OWNER TO postgres;

--
-- TOC entry 209 (class 1259 OID 17538)
-- Name: despesa_mensal_dm_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.despesa_mensal_dm_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.despesa_mensal_dm_id_seq OWNER TO postgres;

--
-- TOC entry 210 (class 1259 OID 17540)
-- Name: despesa_mensal; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.despesa_mensal (
    dm_id bigint DEFAULT nextval('public.despesa_mensal_dm_id_seq'::regclass) NOT NULL,
    dm_empresaid integer NOT NULL,
    dm_empresanome character varying NOT NULL,
    dm_gpid bigint NOT NULL,
    dm_gpdescricao character varying NOT NULL,
    dm_sgpid bigint NOT NULL,
    dm_sgpdescricao character varying NOT NULL,
    dm_data_despesa timestamp without time zone NOT NULL,
    dm_data_inclusao timestamp without time zone DEFAULT now() NOT NULL,
    dm_valor real DEFAULT 0.00 NOT NULL,
    dm_observacao character varying,
    dm_alteracao boolean DEFAULT false NOT NULL,
    dm_fechado boolean DEFAULT false NOT NULL
);


ALTER TABLE public.despesa_mensal OWNER TO postgres;

--
-- TOC entry 182 (class 1259 OID 16396)
-- Name: empresa; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.empresa (
    id bigint NOT NULL,
    nome character varying NOT NULL
);


ALTER TABLE public.empresa OWNER TO postgres;

--
-- TOC entry 181 (class 1259 OID 16394)
-- Name: empresa_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.empresa_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.empresa_id_seq OWNER TO postgres;

--
-- TOC entry 2350 (class 0 OID 0)
-- Dependencies: 181
-- Name: empresa_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.empresa_id_seq OWNED BY public.empresa.id;


--
-- TOC entry 196 (class 1259 OID 16488)
-- Name: entrada_produto; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.entrada_produto (
    id bigint NOT NULL,
    descricao_produto character varying NOT NULL,
    data_entrada date DEFAULT ('now'::text)::date NOT NULL,
    quantidade real DEFAULT 1 NOT NULL,
    fornecedor_id bigint NOT NULL,
    fornecedor_nome character varying NOT NULL,
    produto_id bigint DEFAULT 0 NOT NULL,
    cidade_id bigint DEFAULT 0 NOT NULL,
    cidade_nome character varying NOT NULL
);


ALTER TABLE public.entrada_produto OWNER TO postgres;

--
-- TOC entry 195 (class 1259 OID 16486)
-- Name: entrada_produto_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.entrada_produto_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.entrada_produto_id_seq OWNER TO postgres;

--
-- TOC entry 2351 (class 0 OID 0)
-- Dependencies: 195
-- Name: entrada_produto_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.entrada_produto_id_seq OWNED BY public.entrada_produto.id;


--
-- TOC entry 184 (class 1259 OID 16407)
-- Name: entregador; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.entregador (
    id bigint NOT NULL,
    nome character varying NOT NULL,
    comissao real DEFAULT 0.00 NOT NULL
);


ALTER TABLE public.entregador OWNER TO postgres;

--
-- TOC entry 183 (class 1259 OID 16405)
-- Name: entregador_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.entregador_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.entregador_id_seq OWNER TO postgres;

--
-- TOC entry 2352 (class 0 OID 0)
-- Dependencies: 183
-- Name: entregador_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.entregador_id_seq OWNED BY public.entregador.id;


--
-- TOC entry 186 (class 1259 OID 16419)
-- Name: fornecedor; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.fornecedor (
    id bigint NOT NULL,
    nome character varying NOT NULL,
    comissao_fornecedor real DEFAULT 0.00 NOT NULL,
    comissao_entregador real DEFAULT 0.00 NOT NULL,
    valor_km real DEFAULT 0 NOT NULL
);


ALTER TABLE public.fornecedor OWNER TO postgres;

--
-- TOC entry 185 (class 1259 OID 16417)
-- Name: fornecedor_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.fornecedor_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.fornecedor_id_seq OWNER TO postgres;

--
-- TOC entry 2353 (class 0 OID 0)
-- Dependencies: 185
-- Name: fornecedor_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.fornecedor_id_seq OWNED BY public.fornecedor.id;


--
-- TOC entry 203 (class 1259 OID 17497)
-- Name: grupo_desp_m_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.grupo_desp_m_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.grupo_desp_m_id_seq OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 17499)
-- Name: grupo_desp_m; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.grupo_desp_m (
    gp_id bigint DEFAULT nextval('public.grupo_desp_m_id_seq'::regclass) NOT NULL,
    gp_descricao character varying NOT NULL
);


ALTER TABLE public.grupo_desp_m OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 17599)
-- Name: movimentacao_produto; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.movimentacao_produto (
    id bigint NOT NULL,
    data_movimentacao timestamp without time zone DEFAULT now() NOT NULL,
    produto_id bigint NOT NULL,
    produto_nome character varying NOT NULL,
    fornecedo_id bigint NOT NULL,
    fornecedor_nome character varying,
    entregador_id bigint NOT NULL,
    entregador_nome character varying,
    descricao character varying
);


ALTER TABLE public.movimentacao_produto OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 17597)
-- Name: movimentacao_produto_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.movimentacao_produto_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.movimentacao_produto_id_seq OWNER TO postgres;

--
-- TOC entry 2354 (class 0 OID 0)
-- Dependencies: 215
-- Name: movimentacao_produto_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.movimentacao_produto_id_seq OWNED BY public.movimentacao_produto.id;


--
-- TOC entry 212 (class 1259 OID 17564)
-- Name: pagamento_comissao; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.pagamento_comissao (
    id bigint NOT NULL,
    data_pagamento date DEFAULT ('now'::text)::date NOT NULL,
    entregador_id bigint NOT NULL,
    entregador_nome character varying NOT NULL,
    valor_pago real NOT NULL,
    observacao character varying,
    fornecedor_id bigint DEFAULT 0 NOT NULL,
    fornecedor_nome character varying
);


ALTER TABLE public.pagamento_comissao OWNER TO postgres;

--
-- TOC entry 211 (class 1259 OID 17562)
-- Name: pagamento_comissao_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.pagamento_comissao_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.pagamento_comissao_id_seq OWNER TO postgres;

--
-- TOC entry 2355 (class 0 OID 0)
-- Dependencies: 211
-- Name: pagamento_comissao_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.pagamento_comissao_id_seq OWNED BY public.pagamento_comissao.id;


--
-- TOC entry 188 (class 1259 OID 16432)
-- Name: produto; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.produto (
    id bigint NOT NULL,
    descricao character varying NOT NULL,
    fornecedor_id bigint NOT NULL,
    fornecedor_nome character varying NOT NULL,
    fornecedor_comissao real DEFAULT 0.00 NOT NULL,
    fornecedor_comissao_entregador real DEFAULT 0.00 NOT NULL,
    adicional_id smallint DEFAULT 0 NOT NULL,
    adicional_descricao character varying,
    adicional_valor real DEFAULT 0.00 NOT NULL,
    data_entrada character varying(10),
    data_saida character varying(10),
    data_entrega character varying(10),
    estoque smallint DEFAULT 1 NOT NULL
);


ALTER TABLE public.produto OWNER TO postgres;

--
-- TOC entry 2356 (class 0 OID 0)
-- Dependencies: 188
-- Name: COLUMN produto.data_entrada; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public.produto.data_entrada IS 'Informar somente data';


--
-- TOC entry 2357 (class 0 OID 0)
-- Dependencies: 188
-- Name: COLUMN produto.data_saida; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public.produto.data_saida IS 'informar somente data';


--
-- TOC entry 187 (class 1259 OID 16430)
-- Name: produto_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.produto_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.produto_id_seq OWNER TO postgres;

--
-- TOC entry 2358 (class 0 OID 0)
-- Dependencies: 187
-- Name: produto_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.produto_id_seq OWNED BY public.produto.id;


--
-- TOC entry 200 (class 1259 OID 16602)
-- Name: rotas; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.rotas (
    id bigint NOT NULL,
    descricao character varying NOT NULL,
    data_rota date DEFAULT ('now'::text)::date NOT NULL,
    fornecedor_id bigint DEFAULT 0 NOT NULL,
    fornecedor_nome character varying,
    valor_km real DEFAULT 0 NOT NULL,
    quantidade_km real DEFAULT 1 NOT NULL,
    total_comissao real DEFAULT 0 NOT NULL
);


ALTER TABLE public.rotas OWNER TO postgres;

--
-- TOC entry 199 (class 1259 OID 16600)
-- Name: rotas_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.rotas_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.rotas_id_seq OWNER TO postgres;

--
-- TOC entry 2359 (class 0 OID 0)
-- Dependencies: 199
-- Name: rotas_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.rotas_id_seq OWNED BY public.rotas.id;


--
-- TOC entry 198 (class 1259 OID 16507)
-- Name: saida_produto; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.saida_produto (
    id bigint NOT NULL,
    data_saida date DEFAULT ('now'::text)::date NOT NULL,
    entregador_id bigint NOT NULL,
    entregador_nome character varying NOT NULL,
    cidade_id bigint NOT NULL,
    cidade_nome character varying NOT NULL,
    produto_id bigint DEFAULT 0,
    produto_descricao character varying NOT NULL,
    quantidade real DEFAULT 1 NOT NULL,
    fornecedor_id bigint NOT NULL,
    fornecedor_nome character varying NOT NULL,
    comisao real DEFAULT 0.00 NOT NULL,
    descricao_rota character varying,
    finalizado boolean DEFAULT false NOT NULL,
    devolvido boolean DEFAULT false NOT NULL,
    data_devolucao date,
    data_entrega date
);


ALTER TABLE public.saida_produto OWNER TO postgres;

--
-- TOC entry 197 (class 1259 OID 16505)
-- Name: saida_produto_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.saida_produto_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.saida_produto_id_seq OWNER TO postgres;

--
-- TOC entry 2360 (class 0 OID 0)
-- Dependencies: 197
-- Name: saida_produto_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.saida_produto_id_seq OWNED BY public.saida_produto.id;


--
-- TOC entry 205 (class 1259 OID 17508)
-- Name: subgrupo_desp_m_sbp_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.subgrupo_desp_m_sbp_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.subgrupo_desp_m_sbp_id_seq OWNER TO postgres;

--
-- TOC entry 206 (class 1259 OID 17510)
-- Name: subgrupo_desp_m; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.subgrupo_desp_m (
    sgp_id bigint DEFAULT nextval('public.subgrupo_desp_m_sbp_id_seq'::regclass) NOT NULL,
    sgp_gpid bigint NOT NULL,
    sgp_gpdescricao character varying NOT NULL,
    sgp_descricao character varying NOT NULL,
    sgp_valorpadrao real DEFAULT 0.00 NOT NULL
);


ALTER TABLE public.subgrupo_desp_m OWNER TO postgres;

--
-- TOC entry 190 (class 1259 OID 16453)
-- Name: valor_adicional; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.valor_adicional (
    id bigint NOT NULL,
    descricao character varying(15) NOT NULL,
    valor real DEFAULT 0.00 NOT NULL
);


ALTER TABLE public.valor_adicional OWNER TO postgres;

--
-- TOC entry 189 (class 1259 OID 16451)
-- Name: valor_adicional_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.valor_adicional_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.valor_adicional_id_seq OWNER TO postgres;

--
-- TOC entry 2361 (class 0 OID 0)
-- Dependencies: 189
-- Name: valor_adicional_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.valor_adicional_id_seq OWNED BY public.valor_adicional.id;


--
-- TOC entry 2122 (class 2604 OID 16465)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cidade ALTER COLUMN id SET DEFAULT nextval('public.cidade_id_seq'::regclass);


--
-- TOC entry 2124 (class 2604 OID 16482)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.configuracoes ALTER COLUMN id SET DEFAULT nextval('public.configuracoes_id_seq'::regclass);


--
-- TOC entry 2144 (class 2604 OID 16621)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.descricao_rota ALTER COLUMN id SET DEFAULT nextval('public.descricao_rota_id_seq'::regclass);


--
-- TOC entry 2107 (class 2604 OID 16399)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.empresa ALTER COLUMN id SET DEFAULT nextval('public.empresa_id_seq'::regclass);


--
-- TOC entry 2126 (class 2604 OID 16491)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.entrada_produto ALTER COLUMN id SET DEFAULT nextval('public.entrada_produto_id_seq'::regclass);


--
-- TOC entry 2108 (class 2604 OID 16410)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.entregador ALTER COLUMN id SET DEFAULT nextval('public.entregador_id_seq'::regclass);


--
-- TOC entry 2110 (class 2604 OID 16422)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.fornecedor ALTER COLUMN id SET DEFAULT nextval('public.fornecedor_id_seq'::regclass);


--
-- TOC entry 2161 (class 2604 OID 17602)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.movimentacao_produto ALTER COLUMN id SET DEFAULT nextval('public.movimentacao_produto_id_seq'::regclass);


--
-- TOC entry 2156 (class 2604 OID 17567)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.pagamento_comissao ALTER COLUMN id SET DEFAULT nextval('public.pagamento_comissao_id_seq'::regclass);


--
-- TOC entry 2114 (class 2604 OID 16435)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produto ALTER COLUMN id SET DEFAULT nextval('public.produto_id_seq'::regclass);


--
-- TOC entry 2138 (class 2604 OID 16605)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rotas ALTER COLUMN id SET DEFAULT nextval('public.rotas_id_seq'::regclass);


--
-- TOC entry 2131 (class 2604 OID 16510)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.saida_produto ALTER COLUMN id SET DEFAULT nextval('public.saida_produto_id_seq'::regclass);


--
-- TOC entry 2120 (class 2604 OID 16456)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.valor_adicional ALTER COLUMN id SET DEFAULT nextval('public.valor_adicional_id_seq'::regclass);


--
-- TOC entry 2180 (class 2606 OID 16558)
-- Name: cidade_nome_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cidade
    ADD CONSTRAINT cidade_nome_key UNIQUE (nome);


--
-- TOC entry 2192 (class 2606 OID 16628)
-- Name: descricao_rota_descricao_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.descricao_rota
    ADD CONSTRAINT descricao_rota_descricao_key UNIQUE (descricao);


--
-- TOC entry 2202 (class 2606 OID 17552)
-- Name: dm_idx; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.despesa_mensal
    ADD CONSTRAINT dm_idx PRIMARY KEY (dm_id);


--
-- TOC entry 2200 (class 2606 OID 17537)
-- Name: dp_id; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.desp_produto
    ADD CONSTRAINT dp_id PRIMARY KEY (dpid);


--
-- TOC entry 2166 (class 2606 OID 16556)
-- Name: entregador_nome_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.entregador
    ADD CONSTRAINT entregador_nome_key UNIQUE (nome);


--
-- TOC entry 2170 (class 2606 OID 16554)
-- Name: fornecedor_nome_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.fornecedor
    ADD CONSTRAINT fornecedor_nome_key UNIQUE (nome);


--
-- TOC entry 2196 (class 2606 OID 17507)
-- Name: gp_idx; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.grupo_desp_m
    ADD CONSTRAINT gp_idx PRIMARY KEY (gp_id);


--
-- TOC entry 2182 (class 2606 OID 16470)
-- Name: idx_cidade; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cidade
    ADD CONSTRAINT idx_cidade PRIMARY KEY (id);


--
-- TOC entry 2206 (class 2606 OID 17596)
-- Name: idx_comissao_fornecedor; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comissao_fornecedor
    ADD CONSTRAINT idx_comissao_fornecedor PRIMARY KEY (id);


--
-- TOC entry 2184 (class 2606 OID 16485)
-- Name: idx_configuracoes; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.configuracoes
    ADD CONSTRAINT idx_configuracoes PRIMARY KEY (id);


--
-- TOC entry 2194 (class 2606 OID 16626)
-- Name: idx_descricao_rota; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.descricao_rota
    ADD CONSTRAINT idx_descricao_rota PRIMARY KEY (id);


--
-- TOC entry 2164 (class 2606 OID 16404)
-- Name: idx_empresa; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.empresa
    ADD CONSTRAINT idx_empresa PRIMARY KEY (id);


--
-- TOC entry 2186 (class 2606 OID 16498)
-- Name: idx_entrada_produto; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.entrada_produto
    ADD CONSTRAINT idx_entrada_produto PRIMARY KEY (id);


--
-- TOC entry 2168 (class 2606 OID 16416)
-- Name: idx_entregador; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.entregador
    ADD CONSTRAINT idx_entregador PRIMARY KEY (id);


--
-- TOC entry 2172 (class 2606 OID 16429)
-- Name: idx_fornecedor; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.fornecedor
    ADD CONSTRAINT idx_fornecedor PRIMARY KEY (id);


--
-- TOC entry 2208 (class 2606 OID 17608)
-- Name: idx_movimentacao_produto; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.movimentacao_produto
    ADD CONSTRAINT idx_movimentacao_produto PRIMARY KEY (id);


--
-- TOC entry 2204 (class 2606 OID 17573)
-- Name: idx_pagamento_comissao; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.pagamento_comissao
    ADD CONSTRAINT idx_pagamento_comissao PRIMARY KEY (id);


--
-- TOC entry 2174 (class 2606 OID 16445)
-- Name: idx_produto; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produto
    ADD CONSTRAINT idx_produto PRIMARY KEY (id);


--
-- TOC entry 2190 (class 2606 OID 16615)
-- Name: idx_rota; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rotas
    ADD CONSTRAINT idx_rota PRIMARY KEY (id);


--
-- TOC entry 2188 (class 2606 OID 16519)
-- Name: idx_saida_produto; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.saida_produto
    ADD CONSTRAINT idx_saida_produto PRIMARY KEY (id);


--
-- TOC entry 2178 (class 2606 OID 16459)
-- Name: idx_valor_adicional; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.valor_adicional
    ADD CONSTRAINT idx_valor_adicional PRIMARY KEY (id);


--
-- TOC entry 2176 (class 2606 OID 16552)
-- Name: produto_descricao_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produto
    ADD CONSTRAINT produto_descricao_key UNIQUE (descricao);


--
-- TOC entry 2198 (class 2606 OID 17519)
-- Name: sbp_idx; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subgrupo_desp_m
    ADD CONSTRAINT sbp_idx PRIMARY KEY (sgp_id);


--
-- TOC entry 2217 (class 2620 OID 16595)
-- Name: dispara_func_altera_estoque_del_saida; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER dispara_func_altera_estoque_del_saida AFTER DELETE ON public.saida_produto FOR EACH ROW EXECUTE PROCEDURE public.altera_estoque_produto_del_saida();


--
-- TOC entry 2219 (class 2620 OID 16599)
-- Name: dispara_func_altera_estoque_insert_saida; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER dispara_func_altera_estoque_insert_saida AFTER INSERT ON public.saida_produto FOR EACH ROW EXECUTE PROCEDURE public.altera_estoque_produto_insert_saida();


--
-- TOC entry 2218 (class 2620 OID 16597)
-- Name: dispara_func_altera_estoque_update_saida; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER dispara_func_altera_estoque_update_saida AFTER UPDATE ON public.saida_produto FOR EACH ROW EXECUTE PROCEDURE public.altera_estoque_produto_update_saida();


--
-- TOC entry 2215 (class 2620 OID 17624)
-- Name: trigger_movimentacao_produto_delete_produto; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER trigger_movimentacao_produto_delete_produto AFTER DELETE ON public.produto FOR EACH ROW EXECUTE PROCEDURE public.movimentacao_produto_delete_produto();


--
-- TOC entry 2220 (class 2620 OID 17610)
-- Name: trigger_movimentacao_produto_insert; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER trigger_movimentacao_produto_insert AFTER INSERT ON public.saida_produto FOR EACH ROW EXECUTE PROCEDURE public.movimentacao_produto_insert();


--
-- TOC entry 2216 (class 2620 OID 17622)
-- Name: trigger_movimentacao_produto_insert_entrada; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER trigger_movimentacao_produto_insert_entrada AFTER INSERT ON public.entrada_produto FOR EACH ROW EXECUTE PROCEDURE public.movimentacao_produto_insert_entrada();


--
-- TOC entry 2221 (class 2620 OID 17612)
-- Name: trigger_movimentacao_produto_update; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER trigger_movimentacao_produto_update AFTER UPDATE ON public.saida_produto FOR EACH ROW EXECUTE PROCEDURE public.movimentacao_produto_update();


--
-- TOC entry 2211 (class 2606 OID 16520)
-- Name: fk_entregador; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.saida_produto
    ADD CONSTRAINT fk_entregador FOREIGN KEY (entregador_id) REFERENCES public.entregador(id);


--
-- TOC entry 2213 (class 2606 OID 16530)
-- Name: fk_forncecador; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.saida_produto
    ADD CONSTRAINT fk_forncecador FOREIGN KEY (fornecedor_id) REFERENCES public.fornecedor(id);


--
-- TOC entry 2212 (class 2606 OID 16525)
-- Name: fk_produto; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.saida_produto
    ADD CONSTRAINT fk_produto FOREIGN KEY (produto_id) REFERENCES public.produto(id);


--
-- TOC entry 2209 (class 2606 OID 16446)
-- Name: idfk_fornecedor; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.produto
    ADD CONSTRAINT idfk_fornecedor FOREIGN KEY (fornecedor_id) REFERENCES public.fornecedor(id);


--
-- TOC entry 2210 (class 2606 OID 16499)
-- Name: pk_entrada_fornecedor_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.entrada_produto
    ADD CONSTRAINT pk_entrada_fornecedor_id FOREIGN KEY (fornecedor_id) REFERENCES public.fornecedor(id);


--
-- TOC entry 2214 (class 2606 OID 17520)
-- Name: sbp_gpidx; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subgrupo_desp_m
    ADD CONSTRAINT sbp_gpidx FOREIGN KEY (sgp_gpid) REFERENCES public.grupo_desp_m(gp_id);


--
-- TOC entry 2343 (class 0 OID 0)
-- Dependencies: 6
-- Name: SCHEMA public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


-- Completed on 2023-05-26 16:23:38

--
-- PostgreSQL database dump complete
--

