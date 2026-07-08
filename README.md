# URL Shortener

A URL shortener application built for educational purposes, deployed on Kubernetes.

> **Note:** This project is for learning and experimentation only — not intended for production use.

---

## Functional Requirements

- Authors can create short URLs by providing a full URL to be shortened
- Authors can view and manage their existing short URLs
- Each generated short URL is unique to prevent any conflicts
- Access is restricted to authorized team members only
- Users are automatically redirected from short URLs to their original long URLs

---

## Non-Functional Requirements

### Performance

| Metric | Value |
|--------|-------|
| Write throughput | 1,000 create operations/second |
| Read/write ratio | 1,000 : 1 |
| Read throughput | ~1,000,000 redirects/second |

### Short Code Length — Capacity Calculation

Short codes use a base-62 character set: digits `0-9`, lowercase `a-z`, uppercase `A-Z` — **62 possible characters per position**.

To pick a safe code length we calculate how many unique codes are needed to last without collision:

**Step 1 — codes consumed per year at target write load:**
```
1,000 creates/sec × 60 sec × 60 min × 24 hr × 365 days ≈ 31.5 billion/year
```

**Step 2 — compare code length options:**

| Length | Combinations | Years of capacity |
|--------|-------------|-------------------|
| 6 chars | 62⁶ ≈ 56 billion | ~1.5 years |
| 7 chars | 62⁷ ≈ 3.5 trillion | ~112 years |

**Decision: 7 characters.** Six characters would exhaust within two years at target load. Seven characters provides ~112 years of headroom — more than sufficient.
