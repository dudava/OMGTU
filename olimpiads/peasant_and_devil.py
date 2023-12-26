def check(m, k, z):
    n_a = 1
    while n_a <= z:
        m = m * 2 - k
        n_a += 1
    if m == 0:
        return 1

max_n = int(input())
count = 0
for n in range(1, max_n+1):
    for z in range(1, 54):
        k = (n * 2 ** z) / (2 ** z - 1)
        if k.is_integer():
            #print(n, k, z)
            count += 1
print(count)
