﻿using System.Threading.Tasks;
using NUnit.Framework;

namespace BscScanner.Tests {
    internal class AccountsApiTests {

        private static readonly IBscScanClient BscScanClient = new BscScanClient("7SYTNQ2B5SS7GR4WATVTFXP52BWSUK5PUJ");

        [Test]
        public async Task RunSingleBalanceTest() {
            var balance = await BscScanClient.GetBnbBalanceSingleAsync("0x29980bc85603c8b2a335e5375b57634a1fcef64b");

            Assert.AreEqual(balance, 0f);
        }

        [Test]
        public async Task RunMultipleBalanceTest() {
            var balance = await BscScanClient.GetBnbBalanceMultipleAsync(new[] {
                "0x0000000000000000000000000000000000001004",
                "0x59784ccC71205eF6A292F973e44f46CdC1f58306",
                "0x4430b3230294d12c6ab2aac5c2cd68e80b16b581",
                "0x0caac5b6074b04226d9731ad4868f9d26971b2a8",
                "0xa56b49db164d37be2f5df2830db0c666380cea66"
            });

            foreach ( var bal in balance ) {
                Assert.NotNull(bal);
            }
        }

        [Test]
        public async Task RunGetTransactionsByAddress() {
            var result = await BscScanClient.GetTransactionsByAddress("0x59784ccC71205eF6A292F973e44f46CdC1f58306");

            foreach ( var r in result ) {
                Assert.NotNull(r);
            }
        }

        [Test]
        public async Task RunGetTransactionsByHash() {
            var result =
                await BscScanClient.GetTransactionsByHash(
                    "0x4d74a6fc84d57f18b8e1dfa07ee517c4feb296d16a8353ee41adc03669982028");

            foreach ( var r in result ) {
                Assert.NotNull(r);
            }
        }

        [Test]
        public async Task RunGetTransactionsByBlockRange() {
            var result = await BscScanClient.GetTransactionsByBlockRange(1, 100000);

            foreach ( var r in result ) {
                Assert.NotNull(r);
            }
        }

        [Test]
        public async Task RunGetBep20TokenTransfersByAddress() {
            var result =
                await BscScanClient.GetBep20TokenTransfersByAddress("0x7bb89460599dbf32ee3aa50798bbceae2a5f7f6a");

            foreach ( var r in result ) {
                Assert.NotNull(r);
            }
        }

        [Test]
        public async Task RunGetBep20TokenTransfersByContractAddress()
        {
            var result =
                await BscScanClient.GetBep20TokenTransferByContractAddress("0x7bb89460599dbf32ee3aa50798bbceae2a5f7f6a");

            foreach (var r in result)
            {
                Assert.NotNull(r);
            }
        }

        [Test]
        public async Task RunGetErc721TokenTransfersByAddress() {
            var result =
                await BscScanClient.GetErc721TokenTransfersByAddress("0xcd4ee0a77e09afa8d5a6518f7cf8539bef684e6c");

            foreach ( var r in result ) {
                Assert.NotNull(r);
            }
        }

        [Test]
        public async Task RunGetErc721TokenTransfersByContractAddress()
        {
            var result =
                await BscScanClient.GetErc721TokenTransferByContractAddress("0xc9849e6fdb743d08faee3e34dd2d1bc69ea11a51");

            foreach (var r in result)
            {
                Assert.NotNull(r);
            }
        }

        [Test]
        public async Task RunGetBlocksValidatedByAddress() {
            var result = await BscScanClient.GetBlocksValidatedByAddress("0x78f3adfc719c99674c072166708589033e2d9afe");

            foreach ( var r in result ) {
                Assert.NotNull(r);
            }
        }
    }
}