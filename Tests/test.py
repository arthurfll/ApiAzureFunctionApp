import requests
import random
import time

url = "http://localhost:7071/api/RegistroFunction"

inicio = time.time()

for i in range(1, 501):
    nome = f"Aluno {i}"
    notas = [random.randint(0, 10) for _ in range(4)]
    media = sum(notas) / 4

    dados = {
        "Nome": nome,
        "Nota1": notas[0],
        "Nota2": notas[1],
        "Nota3": notas[2],
        "Nota4": notas[3],
        "Media":0
    }

    try:
        response = requests.post(url, json=dados, timeout=5)
        print(f"[{i}] HTTP {response.status_code}: {response.text.strip()}")
    except requests.RequestException as e:
        print(f"[{i}] Erro na requisição: {e}")

fim = time.time()
print(f"Tempo total: {fim - inicio:.2f} segundos")
